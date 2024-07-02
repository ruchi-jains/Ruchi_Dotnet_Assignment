using Newtonsoft.Json;
using Ruchi_Employee_management_system.DTO;

namespace Ruchi_Employee_management_system.Common
{
    public class BaseEntity
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }



        [JsonProperty(PropertyName = "dType", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "updatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updatedOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "archived", NullValueHandling = NullValueHandling.Ignore)]
        public bool Archived { get; set; }

        public void Initialize(bool isNew, string dType, string createdOrpdatedBy, string createdOrUpdatedByName)
        {
            DocumentType = dType;
       /*     Id = Guid.NewGuid().ToString();*/
            Active = true;
            Archived = false;
            if (isNew)
            {

                CreatedBy = createdOrpdatedBy;
                CreatedOn = DateTime.Now;
                Version += 1;
                UpdatedBy = createdOrpdatedBy;
                UpdatedOn = DateTime.Now;
            }
        }
        public void InitializeAdditional(bool isNew, string dType, string createdOrpdatedBy, string createdOrUpdatedByName)
        {
            EmployeeBasicDTO employeeBasicDTO1 = new EmployeeBasicDTO();
         
            DocumentType = dType;
            Active = true;
            Archived = false;
            if (isNew)
            {
              
                CreatedBy = createdOrpdatedBy;
                CreatedOn = DateTime.Now;
                Version += 1;
                UpdatedBy = createdOrpdatedBy;
                UpdatedOn = DateTime.Now;
            }
        }
    }
        public class WorkInfo_
        {
            [JsonProperty(PropertyName = "designationName", NullValueHandling = NullValueHandling.Ignore)]
            public string? DesignationName { get; set; }
            [JsonProperty(PropertyName = "departmentName", NullValueHandling = NullValueHandling.Ignore)]
            public string? DepartmentName { get; set; }
            [JsonProperty(PropertyName = "locationName", NullValueHandling = NullValueHandling.Ignore)]
            public string? LocationName { get; set; }
            [JsonProperty(PropertyName = "employeeStatus", NullValueHandling = NullValueHandling.Ignore)]
            public string? EmployeeStatus { get; set; } // Terminated, Active, Resigned etc
            [JsonProperty(PropertyName = "sourceOffice", NullValueHandling = NullValueHandling.Ignore)]
            public string? SourceOfHire { get; set; }
            [JsonProperty(PropertyName = "dateOfJoining", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime DateOfJoining { get; set; } = DateTime.Now;
        }

        public class PersonalDetails_
        {
            [JsonProperty(PropertyName = "dateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime DateOfBirth { get; set; } =DateTime.Now;
            [JsonProperty(PropertyName = "age", NullValueHandling = NullValueHandling.Ignore)]
            public string? Age { get; set; }
            [JsonProperty(PropertyName = "gender", NullValueHandling = NullValueHandling.Ignore)]
            public string? Gender { get; set; }
            [JsonProperty(PropertyName = "religion", NullValueHandling = NullValueHandling.Ignore)]
            public string? Religion { get; set; }
            [JsonProperty(PropertyName = "caste", NullValueHandling = NullValueHandling.Ignore)]
            public string? Caste { get; set; }
            [JsonProperty(PropertyName = "maritalStatus", NullValueHandling = NullValueHandling.Ignore)]
            public string? MaritalStatus { get; set; }
            [JsonProperty(PropertyName = "bloodGroup", NullValueHandling = NullValueHandling.Ignore)]
            public string? BloodGroup { get; set; }
            [JsonProperty(PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
            public string? Height { get; set; }
            [JsonProperty(PropertyName = "weight", NullValueHandling = NullValueHandling.Ignore)]
            public string? Weight { get; set; }
        }
        public class IdentityInfo_
        {
            [JsonProperty(PropertyName = "pan", NullValueHandling = NullValueHandling.Ignore)]
            public string? PAN { get; set; }
            [JsonProperty(PropertyName = "aadhar", NullValueHandling = NullValueHandling.Ignore)]
            public string? Aadhar { get; set; }
            [JsonProperty(PropertyName = "propertyName", NullValueHandling = NullValueHandling.Ignore)]
            public string? Nationality { get; set; }
            [JsonProperty(PropertyName = "passportNumber", NullValueHandling = NullValueHandling.Ignore)]
            public string? PassportNumber { get; set; }
            [JsonProperty(PropertyName = "pfNumber", NullValueHandling = NullValueHandling.Ignore)]
            public string? PFNumber { get; set; }
        }


    public class EmployeeFilterCriteria
    {
        public EmployeeFilterCriteria()
        {

            Filters = new List<FilterCriteria>();
            Employees = new List<EmployeeBasicDTO>();
        }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<FilterCriteria> Filters { get; set; }

        public List<EmployeeBasicDTO> Employees { get; set; }
    }
    public class FilterCriteria
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }

   
}
