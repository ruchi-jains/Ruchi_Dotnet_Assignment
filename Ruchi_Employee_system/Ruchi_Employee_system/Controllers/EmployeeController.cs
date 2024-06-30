using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Ruchi_Employee_system.DTO;
using Ruchi_Employee_system.Entity;
using Ruchi_Employee_system.Interface;
using Ruchi_Employee_system.ServiceFilters;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Ruchi_Employee_system.Controllers
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

      

        [HttpGet]
        public async Task<List<EmployeeBasicDTO>> GetAllEmployeeList()
        {
            var response = await _employeeService.GetAllEmployeeList();
            return response;
        }

     
        [HttpGet]
        public async Task<EmployeeBasicDTO> GetEmployeeByUId(string uId)
        {
            var response = await _employeeService.GetEmployeeByUId(uId);
            return response;
        }

     
         [HttpPost]
           public async Task<EmployeeBasicDTO> UpdateEmployee(string uId, EmployeeBasicDTO employeeBasicDTO)
           {
               var response = await _employeeService.UpdateEmployee(uId, employeeBasicDTO);
               return response;
           }

        [HttpPost]
        public async Task<string> DeleteEmployee(string uId)
        {
            var response = await _employeeService.DeleteEmployee(uId);
            return response;
        }

        private string GetStringFromCell(ExcelWorksheet worksheet, int row, int column)
        {
            var cellValue = worksheet.Cells[row, column].Value;
            return cellValue?.ToString()?.Trim();
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is Empty or null");
            var employees = new List<EmployeeBasicDTO>();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var employee = new EmployeeBasicDTO
                        {
                            Salutory = GetStringFromCell(worksheet, row, 1),
                            FirstName = GetStringFromCell(worksheet, row, 2),
                            MiddleName = GetStringFromCell(worksheet, row, 3),
                            LastName = GetStringFromCell(worksheet, row, 4),
                            NickName = GetStringFromCell(worksheet, row, 5),
                            Email = GetStringFromCell(worksheet, row, 6),
                            Mobile = GetStringFromCell(worksheet, row, 7),
                            EmployeeID = GetStringFromCell(worksheet, row, 8),
                            Role = GetStringFromCell(worksheet, row, 9),
                            ReportingManagerUId = GetStringFromCell(worksheet, row, 10),
                            ReportingManagerName = GetStringFromCell(worksheet, row, 11),
                            Address = GetStringFromCell(worksheet, row, 12),

                        };

                        await AddEmployee(employee);
                        employees.Add(employee);
                    }
                }
            }
                return Ok(employees);


        }

        [HttpGet]

        public async Task<IActionResult> Export()
        {
            var employees = await _employeeService.GetAllEmployeeList();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees");
                worksheet.Cells[1, 1].Value = "Sr.No";
                worksheet.Cells[1, 2].Value = "FirstName";
                worksheet.Cells[1, 3].Value = "LastName";
                worksheet.Cells[1, 4].Value = "Email";

                using (var range = worksheet.Cells[1, 1, 1, 4])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                }

                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];
                    worksheet.Cells[i + 2, 1].Value = i + 1;
                    worksheet.Cells[i + 2, 2].Value = employee.FirstName;
                    worksheet.Cells[i + 2, 3].Value = employee.LastName;
                    worksheet.Cells[i + 2, 4].Value = employee.Email;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                var fileName = "Employees.xlsx";
                return File(stream, "aplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                    
            }
        }
        [HttpGet]

        public async Task<List<EmployeeBasicDTO>> GetAllEmployeeByRole(string role)
        {
            var allemployees = await _employeeService.GetAllEmployeeList();
            List<EmployeeBasicDTO> employees = new List<EmployeeBasicDTO>();
            foreach (var item in allemployees)
            {
                if (item.Role == role)
                {
                    employees.Add(item);
                }
            }
            return employees;
        }
        [HttpPost]
        [ServiceFilter(typeof(EmployeeFilter))]
        public async Task<EmployeeFilterCriteria> GetAllemployeesByPagination(EmployeeFilterCriteria employeeFilterCriteria)
        {
            var response = await _employeeService.GetAllEmployeesByPagination(employeeFilterCriteria);
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
