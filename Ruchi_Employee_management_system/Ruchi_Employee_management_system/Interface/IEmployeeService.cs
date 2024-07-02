using Ruchi_Employee_management_system.DTO;
using Ruchi_Employee_management_system.Common;

namespace Ruchi_Employee_management_system.Interface
{
    public interface IEmployeeService
    {
        Task<EmployeeBasicDTO> AddEmployee(EmployeeBasicDTO employeebasicdto);


        Task<EmployeeAdditionalDTO> AddAdditionalDetails(string uId, EmployeeAdditionalDTO employeeAdditionalDTO);

  
        Task<List<EmployeeBasicDTO>> GetAllEmployeeList();
        Task<List<EmployeeAdditionalDTO>> GetAllAdditionalDetailsList();
        Task<EmployeeBasicDTO> GetEmployeeByUId(string uId);
        Task<EmployeeAdditionalDTO> GetAdditionalByUId(string uId);
        Task<string> UpdateEmployee(EmployeeBasicDTO employeebasicdto);
        Task<string> DeleteEmployee(string Id);

        Task<EmployeeFilterCriteria> GetAllEmployeesBasicByPagination(EmployeeFilterCriteria employeeFilterCriteria);

        Task<EmployeeBasicDTO> AddEmployeeByMakePostRequest(EmployeeBasicDTO employeeBasicDTO);

        Task<List<EmployeeBasicDTO>> GetEmployeeByMakeGetRequest();

 

    }
}
