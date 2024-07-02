using Ruchi_Employee_management_system.Interface;
using Ruchi_Employee_management_system.DTO;
using Ruchi_Employee_management_system.CosmosDB;
using Ruchi_Employee_management_system.Entity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ruchi_Employee_management_system.Common;
using Newtonsoft.Json;

namespace Ruchi_Employee_management_system.Service
{
    public class EmployeeService : IEmployeeService
    {
        public readonly ICosmosDBService _cosmosDBService;
        public readonly IMapper _mapper;

        public EmployeeService(ICosmosDBService cosmosDBService, IMapper mapper)
        {
            _cosmosDBService = cosmosDBService;
            _mapper = mapper;
        }
       
      
        public async Task<EmployeeBasicDTO> AddEmployee(EmployeeBasicDTO employeebasicdto)
        {
            var employeebasic = _mapper.Map<EmployeeBasicDetailsEntity>(employeebasicdto);
            employeebasic.Id = Guid.NewGuid().ToString();
            employeebasic.UId = employeebasic.Id;

            employeebasic.Initialize(true, "management", "Ruchi", "Ruchi");
       

            var response = await _cosmosDBService.AddEmployee(employeebasic);
   
            var responseModel = _mapper.Map<EmployeeBasicDTO>(response);
            responseModel.UId = response.UId;

            return responseModel;
        }


    


        public async Task<EmployeeAdditionalDTO> AddAdditionalDetails(string uId, EmployeeAdditionalDTO employeeAdditionalDTO)
        {

            var response1 = await _cosmosDBService.GetEmployeeByUId(uId);
       

            EmployeeBasicDetailsEntity employeeBasic = new EmployeeBasicDetailsEntity();

            var employeeadditional = _mapper.Map<EmployeeAdditionalDetailsEntity>(employeeAdditionalDTO);
            employeeadditional.EmployeeBasicDetailsUId = response1.UId;
            employeeadditional.Id = Guid.NewGuid().ToString();

            employeeadditional.InitializeAdditional(true, "management", "Ruchi", "Ruchi");

            var response = await _cosmosDBService.UpdateItem(employeeadditional);
      
            var responseModel = _mapper.Map<EmployeeAdditionalDTO>(response);
            responseModel.EmployeeBasicDetailsUId = response.EmployeeBasicDetailsUId;

            return responseModel;
        }



        public async Task<List<EmployeeBasicDTO>> GetAllEmployeeList()
        {
            var employees = await _cosmosDBService.GetAllEmployeeList();
            var employeeDTOs = new List<EmployeeBasicDTO>();
            foreach (var employee in employees)
            {
                var employeeDTO = _mapper.Map<EmployeeBasicDTO>(employee);
                employeeDTO.UId = employee.UId;
 
                employeeDTOs.Add(employeeDTO);
                
            }
            return employeeDTOs;
        }

        public async Task<List<EmployeeAdditionalDTO>> GetAllAdditionalDetailsList()
        {
            var employees = await _cosmosDBService.GetAllAdditionalDetailsList();
            var employeeDTOs = new List<EmployeeAdditionalDTO>();
            foreach (var employee in employees)
            {
              

                var employeeDTO = new EmployeeAdditionalDTO();
                employeeDTO.EmployeeBasicDetailsUId = employee.EmployeeBasicDetailsUId;
                employeeDTO.AlternateEmail = employee.AlternateEmail;
                employeeDTO.AlternateMobile = employee.AlternateMobile;
                employeeDTO.WorkInformation = employee.WorkInformation;
                employeeDTO.PersonalDetails = employee.PersonalDetails;
                employeeDTO.IdentityInformation = employee.IdentityInformation;
                employeeDTOs.Add(employeeDTO);
            }
            return employeeDTOs;

        }

       

        public async Task<EmployeeBasicDTO> GetEmployeeByUId(string uId)

        {
            var response = await _cosmosDBService.GetEmployeeByUId(uId);
    

            var employeeBasicDTO = _mapper.Map<EmployeeBasicDTO>(response);
            employeeBasicDTO.UId = uId;


            return employeeBasicDTO;
        }

        public async Task<EmployeeAdditionalDTO> GetAdditionalByUId(string uId)
        {
            EmployeeBasicDTO employeeAdditionalDTO1 = new EmployeeBasicDTO();
            var response = await _cosmosDBService.GetAdditionalByUId(uId);
 

            var employeeAdditionalDTO = _mapper.Map<EmployeeAdditionalDTO>(response);
            employeeAdditionalDTO.EmployeeBasicDetailsUId = uId;
           

            return employeeAdditionalDTO;
        }
        public async Task<string> UpdateEmployee(EmployeeBasicDTO employeeDTO)
        {
            var existingEmployee = await _cosmosDBService.GetEmployeeByUId(employeeDTO.UId);
            if (existingEmployee == null)
            {
                
                return null; 
            }

            existingEmployee.Active = false;
            existingEmployee.Archived = true;
            await _cosmosDBService.UpsertItem(existingEmployee);
            existingEmployee.Initialize(false, "management", "Ruchi", "Ruchi");


            _mapper.Map(employeeDTO, existingEmployee);




             await _cosmosDBService.UpsertItem(existingEmployee);
    

            return "updated";
        }
        public async Task<string> DeleteEmployee(string uId)
        {
          await _cosmosDBService.DeleteEmployee(uId);
          return "record deleted";

        }

        public async Task<EmployeeFilterCriteria> GetAllEmployeesBasicByPagination(EmployeeFilterCriteria employeeFilterCriteria)
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
