using Ruchi_Employee_system.Entity;

namespace Ruchi_Employee_system.CosmosDB
{
    public interface ICosmosDBService
    {
        Task<EmployeeBasicDetailsEntity> AddEmployee(EmployeeBasicDetailsEntity employeebasic);

        Task<List<EmployeeBasicDetailsEntity>> GetAllEmployeeList();
        Task <List<EmployeeBasicDetailsEntity>> GetAllEmployeeByRole(string role);
       Task<EmployeeBasicDetailsEntity> GetEmployeeByUId(string uId);

       Task ReplaceAsync(EmployeeBasicDetailsEntity employeebasic);
      
    }
}
