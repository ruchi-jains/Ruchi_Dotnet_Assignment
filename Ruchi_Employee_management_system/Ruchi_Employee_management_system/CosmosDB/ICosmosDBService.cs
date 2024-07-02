using Microsoft.AspNetCore.Mvc;
using Ruchi_Employee_management_system.Entity;

namespace Ruchi_Employee_management_system.CosmosDB
{
    public interface ICosmosDBService
    {
        Task<EmployeeBasicDetailsEntity> AddEmployee(EmployeeBasicDetailsEntity employeebasic);

        Task<EmployeeAdditionalDetailsEntity> AddAdditionalDetails(EmployeeAdditionalDetailsEntity employeeAdditional);

        Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeList();

        Task<List<EmployeeAdditionalDetailsEntity>> GetAllAdditionalDetailsList();
       Task<EmployeeBasicDetailsEntity> GetEmployeeByUId(string uId);

        Task<EmployeeAdditionalDetailsEntity> GetAdditionalByUId(string uId);

      

        Task UpsertItem(EmployeeBasicDetailsEntity employeebasic);

        Task DeleteEmployee(string uId);

        Task<EmployeeAdditionalDetailsEntity> UpdateItem(EmployeeAdditionalDetailsEntity employeeAdditionalDetailsEntity);
    }
}
