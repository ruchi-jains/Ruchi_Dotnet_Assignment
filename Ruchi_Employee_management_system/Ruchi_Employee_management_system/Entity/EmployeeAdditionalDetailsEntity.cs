using Newtonsoft.Json;
using Ruchi_Employee_management_system.Common;

namespace Ruchi_Employee_management_system.Entity
{
  
    public class EmployeeAdditionalDetailsEntity : EmployeeBasicDetailsEntity
    {

        [JsonProperty(PropertyName = "employeeBasicDetailsuId", NullValueHandling = NullValueHandling.Ignore)]
        public string? EmployeeBasicDetailsUId { get; set; } 
        [JsonProperty(PropertyName = "altenateEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string? AlternateEmail { get; set; }
        [JsonProperty(PropertyName = "altenateMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string? AlternateMobile { get; set; }
        [JsonProperty(PropertyName = "workInfo", NullValueHandling = NullValueHandling.Ignore)]
        public WorkInfo_? WorkInformation { get; set; }
        [JsonProperty(PropertyName = "propertyDetails", NullValueHandling = NullValueHandling.Ignore)]
        public PersonalDetails_? PersonalDetails { get; set; }
        [JsonProperty(PropertyName = "identityInfo", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityInfo_? IdentityInformation { get; set; }
    }
}
