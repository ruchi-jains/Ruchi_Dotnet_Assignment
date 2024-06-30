using Ruchi_Employee_system.Interface;
using Ruchi_Employee_system.DTO;
using Ruchi_Employee_system.CosmosDB;
using Ruchi_Employee_system.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ruchi_Employee_system.Common;
using System.Runtime.InteropServices;

namespace Ruchi_Employee_system.Service
{
    public class EmployeeService : IEmployeeService
    {
        public readonly ICosmosDBService _cosmosDBService;

        public EmployeeService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
       
      
        public async Task<EmployeeBasicDTO> AddEmployee(EmployeeBasicDTO employeebasicdto)
        {
            EmployeeBasicDetailsEntity employeebasic = new EmployeeBasicDetailsEntity();
            
            employeebasic.Id = Guid.NewGuid().ToString();
            employeebasic.UId = employeebasic.Id;
            employeebasic.Salutory = employeebasicdto.Salutory;
            employeebasic.FirstName = employeebasicdto.FirstName;
            employeebasic.MiddleName = employeebasicdto.MiddleName;
            employeebasic.LastName = employeebasicdto.LastName;
            employeebasic.NickName = employeebasicdto.NickName;
            employeebasic.Email = employeebasicdto.Email;
            employeebasic.Mobile = employeebasicdto.Mobile;
            employeebasic.EmployeeID = employeebasicdto.EmployeeID;
            employeebasic.Role= employeebasicdto.Role;
            employeebasic.ReportingManagerUId = employeebasicdto.ReportingManagerUId;
            employeebasic.ReportingManagerName = employeebasicdto.ReportingManagerName;
            employeebasic.Address = employeebasicdto.Address;

            employeebasic.Initialize(true, "management", "Ruchi", "Ruchi");
           /* employeebasic.Id = Guid.NewGuid().ToString();
            employeebasic.UId = employeebasic.Id;
            employeebasic.DocumentType = "management";
            employeebasic.CreatedBy = "ruchi";
            employeebasic.CreatedOn = DateTime.Now;
            employeebasic.UpdatedBy = "ruchi";
            employeebasic.UpdatedOn = DateTime.Now;
            employeebasic.Version = 1;
            employeebasic.Active = true;
            employeebasic.Archived = false;*/
            

            var response = await _cosmosDBService.AddEmployee(employeebasic);
            var responseModel = new EmployeeBasicDTO();
            responseModel.UId = response.UId;   
            responseModel.Salutory = response.Salutory;
            responseModel.FirstName = response.FirstName;
            responseModel.MiddleName = response.MiddleName;
            responseModel.LastName = response.LastName;
            responseModel.NickName = response.NickName;
            responseModel.Email = response.Email;
            responseModel.Mobile = response.Mobile;
            responseModel.EmployeeID = response.EmployeeID;
            responseModel.Role = response.Role;
            responseModel.ReportingManagerUId = response.ReportingManagerUId;
            responseModel.ReportingManagerName = response.ReportingManagerName;
            responseModel.Address = response.Address;

            return responseModel;
        }

       



        public async Task<List<EmployeeBasicDTO>> GetAllEmployeeList()
        {
            var employees = await _cosmosDBService.GetAllEmployeeList();
            var employeeDTOs = new List<EmployeeBasicDTO>();
            foreach (var employee in employees)
            {
                var employeeDTO = new EmployeeBasicDTO();
                employeeDTO.UId = employee.UId;
                employeeDTO.Salutory = employee.Salutory;
                employeeDTO.FirstName = employee.FirstName;
                employeeDTO.MiddleName = employee.MiddleName;
                employeeDTO.LastName = employee.LastName;
                employeeDTO.NickName = employee.NickName;
                employeeDTO.Email = employee.Email;
                employeeDTO.Mobile = employee.Mobile;
                employeeDTO.EmployeeID = employee.EmployeeID;
                employeeDTO.Role = employee.Role;
                employeeDTO.ReportingManagerUId= employee.ReportingManagerUId;  
                employeeDTO.ReportingManagerName= employee.ReportingManagerName;
                employeeDTO.Address = employee.Address;
                employeeDTOs.Add(employeeDTO);
                
            }
            return employeeDTOs;
        }

       

       

        public async Task<EmployeeBasicDTO> GetEmployeeByUId(string uId)

        {
            var response = await _cosmosDBService.GetEmployeeByUId(uId);
            var employeeBasicDTO = new EmployeeBasicDTO();
            employeeBasicDTO.UId = response.UId ;
            employeeBasicDTO.EmployeeID = response.EmployeeID;
            employeeBasicDTO.Salutory = response.Salutory;
            employeeBasicDTO.FirstName = response.FirstName;
            employeeBasicDTO.MiddleName = response.MiddleName;
            employeeBasicDTO.LastName = response.LastName;
            employeeBasicDTO.NickName = response.NickName;
            employeeBasicDTO.Email = response.Email;
            employeeBasicDTO.Mobile = response.Mobile;
            employeeBasicDTO.Role = response.Role;
            employeeBasicDTO.ReportingManagerUId = response.ReportingManagerUId;
            employeeBasicDTO.ReportingManagerName = response.ReportingManagerName;
            employeeBasicDTO.Address = response.Address;


            return employeeBasicDTO;
        }
     
        public async Task<EmployeeBasicDTO> UpdateEmployee(string uId, EmployeeBasicDTO employeeDTO)
        {
            var existingEmployee = await _cosmosDBService.GetEmployeeByUId(uId);
            existingEmployee.Active = false;
            existingEmployee.Archived = true;
            await _cosmosDBService.ReplaceAsync(existingEmployee);
            existingEmployee.Initialize(false, "management", "Ruchi", "Ruchi");
            
            existingEmployee.Salutory = employeeDTO.Salutory;
            existingEmployee.FirstName = employeeDTO.FirstName;
            existingEmployee.MiddleName = employeeDTO.MiddleName;
            existingEmployee.LastName = employeeDTO.LastName;
            existingEmployee.NickName = employeeDTO.NickName;
            existingEmployee.Email = employeeDTO.Email;
            existingEmployee.EmployeeID = employeeDTO.EmployeeID;
            existingEmployee.Role = employeeDTO.Role;   
            existingEmployee.Mobile = employeeDTO.Mobile;
            existingEmployee.ReportingManagerUId = employeeDTO.ReportingManagerUId;
            existingEmployee.ReportingManagerName = employeeDTO.ReportingManagerName;
            existingEmployee.Address = employeeDTO.Address;

            var response = await _cosmosDBService.AddEmployee(existingEmployee);    
            var responseModel = new EmployeeBasicDTO
            {
                UId = employeeDTO.UId,
                EmployeeID = response.EmployeeID,
                Salutory = response.Salutory,
                FirstName = response.FirstName,
                MiddleName = response.MiddleName,
                LastName = response.LastName,
                NickName = response.NickName,
                Email = response.Email,
                Mobile = response.Mobile,
                Role = response.Role,
                ReportingManagerUId = response.ReportingManagerUId,
                ReportingManagerName = response.ReportingManagerName,
                Address = response.Address,
            };
            return responseModel;
        }

        public async Task<string> DeleteEmployee(string uId)
        {
            var employee = await _cosmosDBService.GetEmployeeByUId(uId);
            employee.Active = false;
            employee.Archived = true;
            await _cosmosDBService.ReplaceAsync(employee);
            employee.Initialize(false, "management", "Ruchi", "Ruchi");
            employee.Active = false;
            await _cosmosDBService.AddEmployee(employee);


            return "record deleted";


        }

        public async Task<List<EmployeeBasicDTO>> GetAllEmployeeByRole(string role)
        {
            var allemployees = await GetAllEmployeeList();
            return allemployees.FindAll(a => a.Role == role);
        }

        public async Task<EmployeeFilterCriteria> GetAllEmployeesByPagination(EmployeeFilterCriteria employeeFilterCriteria)
        {
            EmployeeFilterCriteria responseObject = new EmployeeFilterCriteria();
            var checkFilter = employeeFilterCriteria.Filters.Any(a => a.FieldName == "role");
            var role = "";
            if (checkFilter)
            {
                role = employeeFilterCriteria.Filters.Find(a => a.FieldName == "role").FieldValue;
            }
            var employees = await GetAllEmployeeList();
            var filteredRecords = employees.FindAll(a => a.Role == role);
            responseObject.TotalCount = employees.Count;
            responseObject.Page = employeeFilterCriteria.Page;
            responseObject.PageSize = employeeFilterCriteria.PageSize;
            var skip = employeeFilterCriteria.PageSize * (employeeFilterCriteria.Page - 1);
            filteredRecords = filteredRecords.Skip(skip).Take(employeeFilterCriteria.PageSize).ToList();
            foreach (var item in filteredRecords)
            {
                responseObject.Employees.Add(item);
            }
            return responseObject;

        }

        public async Task<EmployeeBasicDTO> AddEmployeeByMakePostRequest(EmployeeBasicDTO employeeBasicDTO)
        {
            var serializedObj = JsonConvert.SerializeObject(employeeBasicDTO);
            var requestObj = await HttpClientHelper.MakePostRequest(Credentials.EmployeeUrl, Credentials.AddEmployeeEndpoint, serializedObj);
            var responseObj = JsonConvert.DeserializeObject<EmployeeBasicDTO>(requestObj);
            return responseObj;
        }

        public async Task<List<EmployeeBasicDTO>> GetEmployeeByMakeGetRequest()
        {
            var responseObj = await HttpClientHelper.MakeGetRequest(Credentials.EmployeeUrl, Credentials.Endpoint);
            var response = JsonConvert.DeserializeObject<List<EmployeeBasicDTO>>(responseObj);
            return response;
        }
       
    }
}
