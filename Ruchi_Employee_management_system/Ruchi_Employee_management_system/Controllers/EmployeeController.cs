using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using Ruchi_Employee_management_system.Common;
using Ruchi_Employee_management_system.DTO;
using Ruchi_Employee_management_system.Interface;
using Ruchi_Employee_management_system.ServiceFilters;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Ruchi_Employee_management_system.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<EmployeeBasicDTO> AddEmployee(EmployeeBasicDTO employeeBasicDTO)
        {
            var response =  await _employeeService.AddEmployee(employeeBasicDTO);
            return response;
        }

        [HttpPost]
        public async Task<EmployeeAdditionalDTO> AddAdditionalDetails(string uId, EmployeeAdditionalDTO employeeAdditional)
        {
            var response = await _employeeService.AddAdditionalDetails(uId, employeeAdditional);
            return response;
        }

        [HttpGet]
        public async Task<List<EmployeeBasicDTO>> GetAllEmployeeList()
        {
            var response = await _employeeService.GetAllEmployeeList();
            return response;
        }

        [HttpGet]
       
        public async Task<List<EmployeeAdditionalDTO>> GetAllAdditional()
        {
            var response = await _employeeService.GetAllAdditionalDetailsList();
            return response;
        }
        [HttpGet]
      
        public async Task<EmployeeBasicDTO> GetEmployeeByUId(string uId)
        {
            var response = await _employeeService.GetEmployeeByUId(uId);
            return response;
        }

        [HttpGet]
        [Route("Employee/{uId}")]
        public async Task<EmployeeAdditionalDTO> GetAdditionalByUId(string uId)
        {
            var response = await _employeeService.GetAdditionalByUId(uId);
            return response;
        }
         [HttpPut]
           public async Task<string> UpdateEmployee(EmployeeBasicDTO employeeBasicDTO)
           {
               var response = await _employeeService.UpdateEmployee(employeeBasicDTO);
               return response;
           }

        [HttpDelete]
            public async Task<string> DeleteEmployee(string Id)
        {
            var response = await _employeeService.DeleteEmployee(Id);
            return "Deleted";
        }

      

        [HttpGet]

        public async Task<IActionResult> Export()
        {
            var employees = await _employeeService.GetAllEmployeeList();
            var employeeAdditional = await _employeeService.GetAllAdditionalDetailsList();
           
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees");

               
                worksheet.Cells[1, 1].Value = "Sr.No";
                worksheet.Cells[1, 2].Value = "Salutory";
                worksheet.Cells[1, 3].Value = "FirstName";
                worksheet.Cells[1, 4].Value = "MiddleName";
                worksheet.Cells[1, 5].Value = "Lastname";
                worksheet.Cells[1, 6].Value = "NickName";
                worksheet.Cells[1, 7].Value = "Email";
                worksheet.Cells[1, 8].Value = "Mobile";
                worksheet.Cells[1, 9].Value = "Employee_ID";
                worksheet.Cells[1, 10].Value = "Role";
                worksheet.Cells[1, 11].Value = "Reporting manager UId";
                worksheet.Cells[1, 12].Value = "Reporting manager Name";
                worksheet.Cells[1, 13].Value = "Address";
                worksheet.Cells[1, 14].Value = "EmployeeBasicUId";
                worksheet.Cells[1, 15].Value = "AlternateEmail";
                worksheet.Cells[1, 16].Value = "AlternateMobile";
                worksheet.Cells[1, 17].Value = "DateOfBirth";
                worksheet.Cells[1, 18].Value = "DateOfJoining";
                worksheet.Cells[1, 19].Value = "Aadhar";


                using (var range = worksheet.Cells[1, 1, 1, 19])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                }
                 int i = 1;
                Action<EmployeeBasicDTO, int> mapToExcelRow = (employee, row) =>
                {
                     
                    worksheet.Cells[row, 1].Value = i;
                    worksheet.Cells[row, 2].Value = employee.Salutory;
                    worksheet.Cells[row, 3].Value = employee.FirstName;
                    worksheet.Cells[row, 4].Value = employee.MiddleName;
                    worksheet.Cells[row, 5].Value = employee.LastName;
                    worksheet.Cells[row, 6].Value = employee.NickName;
                    worksheet.Cells[row, 7].Value = employee.Email;
                    worksheet.Cells[row, 8].Value = employee.Mobile;
                    worksheet.Cells[row, 9].Value = employee.EmployeeID;
                    worksheet.Cells[row, 10].Value = employee.Role;
                    worksheet.Cells[row, 11].Value = employee.ReportingManagerUId;
                    worksheet.Cells[row, 12].Value = employee.ReportingManagerName;
                    worksheet.Cells[row, 13].Value = employee.Address;
                   
                 
                };

               
                int row = 2;
                foreach (var employee in employees)
                {
                    mapToExcelRow(employee, row);
                    row++;
                    i++;
                }

                for (int j = 0; j < employeeAdditional.Count; j++)
                {
                    var employee1 = employeeAdditional[j];
                    worksheet.Cells[j + 2, 14].Value = employee1.EmployeeBasicDetailsUId;
                    worksheet.Cells[j + 2, 15].Value = employee1.AlternateEmail;
                    worksheet.Cells[j + 2, 16].Value = employee1.AlternateMobile;
                    worksheet.Cells[j + 2, 17].Value = employee1.PersonalDetails?.DateOfBirth;
                    worksheet.Cells[j + 2, 18].Value = employee1.WorkInformation?.DateOfJoining;
                    worksheet.Cells[j + 2, 19].Value = employee1.IdentityInformation?.Aadhar;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                var fileName = "Employees.xlsx";
                return File(stream, "aplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(EmployeeFilter))]
        public async Task<EmployeeFilterCriteria> GetAllemployeesBasicByPagination(EmployeeFilterCriteria employeeFilterCriteria)
        {
            var response = await _employeeService.GetAllEmployeesBasicByPagination(employeeFilterCriteria);
            return response;
        }

        [HttpPost]

        public async Task<EmployeeBasicDTO> AddEmployeeByMakePostRequest(EmployeeBasicDTO employeeBasic)
        {
            var response = await _employeeService.AddEmployeeByMakePostRequest(employeeBasic);
            return response;
        }

        [HttpGet]

        public async Task<List<EmployeeBasicDTO>> GetEmployeeByMakeGetRequest()
        {
            var response = await _employeeService.GetEmployeeByMakeGetRequest();
            return response;
        }

     

    }
}
