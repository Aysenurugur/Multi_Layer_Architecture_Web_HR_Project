using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
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
    public class UserController : ControllerBase
    {
        IUserService userService;
        ICompanyService companyService;
        IMapper mapper;
        public UserController(IUserService userService, ICompanyService companyService, IMapper mapper)
        {
            this.userService = userService;
            this.companyService = companyService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployerDTO employerDTO)
        {
            try
            {
                Company company = new Company()
                {
                    CompanyID = new Guid(),
                    CompanyName = employerDTO.CompanyName
                };

                User user = mapper.Map<RegisterEmployerDTO, User>(employerDTO);
                user.Id = new Guid();

                await companyService.CreateCompany(company);
                user.CompanyID = company.CompanyID;
                var result = await userService.RegisterAsync(user, employerDTO.Password);
                if (result != null) return BadRequest(result); //result list dolu ise error ları ekranda göster
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterEmployeeDTO employeeDTO)
        {
            try
            {
                bool checkMail = await userService.CheckUserMailAsync(employeeDTO.Email);
                bool checkPhone = await userService.CheckUserPhoneNumberAsync(employeeDTO.Phone);

                if (!checkMail) return BadRequest("Geçerli bir mail adresi kullanın.");
                if (!checkPhone) return BadRequest("Geçerli bir telefon numarası kullanın.");

                User user = mapper.Map<RegisterEmployeeDTO, User>(employeeDTO);
                user.Id = new Guid();

                var check = await userService.RegisterAsync(user, null);
                return Ok(check);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeactivateUser(Guid id)
        {
            try
            {
                User user = await userService.GetUserById(id);
                bool check;
                if (await userService.CheckIfRoleIsManager(id)) check = await userService.DeactivateAllEmployeesAsync(user.CompanyID);
                else check = await userService.SetUserStatusAsync(id, false);
                return Ok(check);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
