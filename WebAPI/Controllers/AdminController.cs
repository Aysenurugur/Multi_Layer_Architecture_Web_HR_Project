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
        public AdminController(ICompanyService companyService, IMapper mapper, IAdminService adminService)
        {
            this.companyService = companyService;
            this.mapper = mapper;
            this.adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> Companies()
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

        [HttpPut("{id}")]
        public async Task<IActionResult> DeactivateCompany(Guid id)
        {
            try
            {
                bool check = await companyService.DeactivateCompany(id);
                return Ok(check); 
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
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

        // GetDayOFFType
        // CreateDayOffType
    }
}
