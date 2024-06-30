using Ruchi_Employee_system.DTO;
using Ruchi_Employee_system.Entity;

namespace Ruchi_Employee_system.Interface
{
    public interface IEmployeeService
    {
        Task<EmployeeBasicDTO> AddEmployee(EmployeeBasicDTO employeebasicdto);
       
        Task<List<EmployeeBasicDTO>> GetAllEmployeeList();
 
        Task<EmployeeBasicDTO> GetEmployeeByUId(string uId);
     
        Task<EmployeeBasicDTO> UpdateEmployee(string uId, EmployeeBasicDTO employeebasicdto);

        Task<List<EmployeeBasicDTO>> GetAllEmployeeByRole(string role);

        Task<EmployeeFilterCriteria> GetAllEmployeesByPagination(EmployeeFilterCriteria employeeFilterCriteria);

       Task<EmployeeBasicDTO> AddEmployeeByMakePostRequest(EmployeeBasicDTO employeeBasicDTO);

        Task<List<EmployeeBasicDTO>> GetEmployeeByMakeGetRequest();
     

        Task<string>  DeleteEmployee(string uId);
    }
}
