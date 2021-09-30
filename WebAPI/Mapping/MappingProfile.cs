using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using WebAPI.DTOs;

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //GET
            CreateMap<Comment, CommentDTO>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<User, EmployeeDetailsDTO>();
            CreateMap<DayOff, EmployeeDayOffDTO>();

            //POST
            CreateMap<RegisterEmployerDTO, User>();
            CreateMap<RegisterEmployeeDTO, User>();
        }
    }
}
