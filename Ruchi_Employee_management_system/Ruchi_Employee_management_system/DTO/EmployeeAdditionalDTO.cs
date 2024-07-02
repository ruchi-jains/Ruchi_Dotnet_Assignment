using Newtonsoft.Json;
using Ruchi_Employee_management_system.Common;

namespace Ruchi_Employee_management_system.DTO
{
    public class EmployeeAdditionalDTO : EmployeeBasicDTO
    {
        [JsonProperty(PropertyName = "employeeBasicDetailuId", NullValueHandling = NullValueHandling.Ignore)]
        public string? EmployeeBasicDetailsUId { get; set; } 
        [JsonProperty(PropertyName = "alternateEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string? AlternateEmail { get; set; }
        [JsonProperty(PropertyName = "alternateMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string? AlternateMobile { get; set; }
        [JsonProperty(PropertyName = "workInfo", NullValueHandling = NullValueHandling.Ignore)]
        public WorkInfo_? WorkInformation { get; set; }
        [JsonProperty(PropertyName = "personalDetails", NullValueHandling = NullValueHandling.Ignore)]
        public PersonalDetails_? PersonalDetails { get; set; }
        [JsonProperty(PropertyName = "identityInfo", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityInfo_? IdentityInformation { get; set; }

    }
}
