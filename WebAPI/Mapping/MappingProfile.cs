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
            CreateMap<DayOff, EmployeeDayOffDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<DayOffType, DayOffTypeDTO>();
            CreateMap<Expense, ExpenseDTO>();
            CreateMap<DayOff, DayOffDTO>();
            CreateMap<Break, BreakDTO>();
            CreateMap<Shift, ShiftDTO>();
            CreateMap<File, FileDTO>();
            CreateMap<FileType, FileTypeDTO>();
            CreateMap<VetoMessage, VetoMessageDTO>();
            CreateMap<User, UpdateUserDTO>();
            CreateMap<Company, UpdateCompanyDTO>();
            CreateMap<Promotion, PromotionDTO>();


            //DTO to Entity
            CreateMap<RegisterEmployerDTO, User>();
            CreateMap<RegisterEmployeeDTO, User>();
            CreateMap<UserDTO, User>();
            CreateMap<DayOffTypeDTO, DayOffType>();
            CreateMap<CommentDTO, Comment>();
            CreateMap<ExpenseDTO, Expense>();
            CreateMap<DayOffDTO, DayOff>();
            CreateMap<BreakDTO, Break>();
            CreateMap<ShiftDTO, Shift>();
            CreateMap<FileDTO, File>();
            CreateMap<FileTypeDTO, FileType>();
            CreateMap<VetoMessageDTO, VetoMessage>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<UpdateCompanyDTO, Company>();
            CreateMap<PromotionDTO, Promotion>();
        }
    }
}
