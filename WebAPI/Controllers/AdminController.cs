using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        ICompanyService companyService;
        IMapper mapper;
        IAdminService adminService;
        IDayOffTypeService dayOffTypeService;
        IUserService userService;
        public AdminController(ICompanyService companyService, IMapper mapper, IAdminService adminService, IDayOffTypeService dayOffTypeService, IUserService userService)
        {
            this.companyService = companyService;
            this.mapper = mapper;
            this.adminService = adminService;
            this.dayOffTypeService = dayOffTypeService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Companies() //test edildi
        {
            try
            {
                var companies = await companyService.GetAllCompanies();
                var companyDTOs = mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDTO>>(companies);
                return Ok(companyDTOs);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeactivateCompany(Guid id) //test edildi
        {
            try
            {
                bool check = await companyService.DeactivateCompany(id) && await userService.DeactivateAllEmployeesAsync(id);
                return Ok(check);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO) //test edildi
        {
            try
            {
                bool check = await adminService.AdminLoginAsync(loginDTO.Email, loginDTO.Password);
                return Ok(check); //ajax success de dönen data true ise buraya yönlendir, değilse şöyle işlem yap
            }
            catch (Exception)
            {
                return BadRequest();
         
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetDayOffTypes() //Test edildi.
        {
            try
            {
                var dayOffTypes = await dayOffTypeService.GetAllDayOffTypes();
                var dayOffTypeDTOs = mapper.Map<IEnumerable<DayOffType>, IEnumerable<DayOffTypeDTO>>(dayOffTypes);
                return Ok(dayOffTypeDTOs);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        

    }
}
//"email" : "deneme@gmail.com",
//    "password" : "Abceeee8."