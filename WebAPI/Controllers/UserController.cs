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
        public async Task<IActionResult> Register(RegisterEmployerDTO employerDTO) //test edild
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
                var result = await userService.RegisterAsync(user, employerDTO.Password, "Employer");
                if (result != null) return BadRequest(result); //result list dolu ise error ları ekranda göster
                UserDTO userDTO = mapper.Map<User, UserDTO>(user);

                return Ok(userDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterEmployeeDTO employeeDTO) //test edildi
        {
            try
            {
                User user = mapper.Map<RegisterEmployeeDTO, User>(employeeDTO);
                user.Id = new Guid();

                var result = await userService.RegisterAsync(user, userService.CreateRandomPassword(), "");
                if (result != null) return BadRequest(result); //result list dolu ise error ları ekranda göster

                UserDTO userDTO = mapper.Map<User, UserDTO>(user);
                return Ok(userDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeactivateUser(Guid id) //test edildi
        {
            try
            {
                User user = await userService.GetUserById(id);
                bool check;
                if (await userService.CheckIfRoleIsEmployerAsync(id)) check = await userService.DeactivateAllEmployeesAsync(user.CompanyID);
                else check = await userService.SetUserStatusAsync(id, false);
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
                bool check = await userService.UserLoginAsync(loginDTO.Email, loginDTO.Password);
                if (!check) return BadRequest("Bilgilerinizi kontrol ediniz.");
                User user = await userService.GetUserByEmailAsync(loginDTO.Email);

                if (!user.IsActive) return BadRequest("Artık aktif bir üye değilsiniz.");

                UserDTO userDTO = mapper.Map<User, UserDTO>(user);
                return Ok(userDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
