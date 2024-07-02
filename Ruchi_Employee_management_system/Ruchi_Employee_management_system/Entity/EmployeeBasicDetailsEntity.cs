using Newtonsoft.Json;
using System.Net;
using Ruchi_Employee_management_system.Common;

namespace Ruchi_Employee_management_system.Entity
{
    public class EmployeeBasicDetailsEntity :BaseEntity

    {
        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "salutory", NullValueHandling = NullValueHandling.Ignore)]
        public string? Salutory { get; set; }
        [JsonProperty(PropertyName = "first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? FirstName { get; set; }
        [JsonProperty(PropertyName = "middle_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? MiddleName { get; set; }
        [JsonProperty(PropertyName = "last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? LastName { get; set; }
        [JsonProperty(PropertyName = "nick_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? NickName { get; set; }
        

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string? Email { get; set; }
        [JsonProperty(PropertyName = "mobile", NullValueHandling = NullValueHandling.Ignore)]
        public string? Mobile { get; set; }
        [JsonProperty(PropertyName = "employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string? EmployeeID { get; set; }
        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public string?   Role { get; set; }
        [JsonProperty(PropertyName = "reporting_manager_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string? ReportingManagerUId { get; set; }
        [JsonProperty(PropertyName = "reporting_manager_name", NullValueHandling = NullValueHandling.Ignore)]
        public string? ReportingManagerName { get; set; }
        [JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Ignore)]
        public string? Address { get; set; }

   
    }

   
}
