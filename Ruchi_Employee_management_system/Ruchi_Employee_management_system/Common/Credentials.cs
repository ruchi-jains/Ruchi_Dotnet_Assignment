namespace Ruchi_Employee_management_system.Common
{
    public class Credentials
    {
        internal static readonly string databaseName = Environment.GetEnvironmentVariable("databaseName");
        internal static readonly string containerName = Environment.GetEnvironmentVariable("containerName");
        internal static readonly string CosmosEndpoint = Environment.GetEnvironmentVariable("cosmosUrl");
        internal static readonly string PrimaryKey = Environment.GetEnvironmentVariable("primaryKey");
        internal static readonly string EmployeeUrl = Environment.GetEnvironmentVariable("EmployeeUrl");
        internal static readonly string AddEmployeeEndpoint = "/api/Employee/AddEmployee";
        internal static readonly string Endpoint = "/api/Employee/GetAllEmployeeList";
    }
}
