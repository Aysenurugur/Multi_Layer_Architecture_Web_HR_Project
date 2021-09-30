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
            //Entity to DTO
            CreateMap<Comment, CommentDTO>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<User, EmployeeDetailsDTO>();
            
            //DTO to Entity
            CreateMap<RegisterEmployerDTO, User>();
            CreateMap<RegisterEmployeeDTO, User>();
            CreateMap<UserDTO, User>();
        }
    }
}
