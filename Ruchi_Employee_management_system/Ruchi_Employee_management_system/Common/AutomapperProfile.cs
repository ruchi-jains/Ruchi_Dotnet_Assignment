using AutoMapper;
using Ruchi_Employee_management_system.DTO;
using Ruchi_Employee_management_system.Entity;

namespace Ruchi_Employee_management_system.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<EmployeeBasicDetailsEntity, EmployeeBasicDTO>().ForMember(n => n.UId, opt => opt.Ignore()).ReverseMap();

            CreateMap<EmployeeAdditionalDetailsEntity, EmployeeAdditionalDTO>().ForMember(n => n.EmployeeBasicDetailsUId, opt => opt.Ignore()).ReverseMap();

        }

    }
}
