using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using Core.Entities.Identity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public EmployeeController(IUserService _userService, IMapper _mapper)
        {
            this.userService = _userService;
            this.mapper = _mapper;
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetEmployee(Guid id) // test edildi
        {
            var employee = await userService.GetUserById(id);
            var employeeDTO = mapper.Map<User, EmployeeDetailsDTO>(employee);
            return Ok(employee);
        }
    }
}
