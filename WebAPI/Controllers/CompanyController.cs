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
    public class CompanyController : ControllerBase
    {
        //CompanyList??
        //EmployeesByCompanyId
        //DayOffsByCompanyId
        //ShiftsByCompanyId
        ICompanyService companyService;
        IDayOffService dayOffService;
        IMapper mapper;
        public CompanyController(ICompanyService companyService, IDayOffService dayOffService, IMapper mapper)
        {
            this.companyService = companyService;
            this.dayOffService = dayOffService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(Guid id)  //Test edildi.
        {
            try
            {
                var company = await companyService.GetCompanyById(id);
                var companyDTO = mapper.Map<Company, CompanyDTO>(company);
                return Ok(companyDTO);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesByCompanyId(Guid id) //test edildi
        {
            try
            {
                var employees = await companyService.GetEmployeesByCompanyId(id);
                var employeeDTOs = mapper.Map<IEnumerable<User>, IEnumerable<EmployeeDetailsDTO>>(employees);
                return Ok(employeeDTOs);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DayOffsByCompanyId(Guid id) //test edildi
        {
            try
            {
                var dayOffs = await dayOffService.GetDayOffsByCompany(id);
                var dayOffDTOs = mapper.Map<IEnumerable<DayOff>, IEnumerable<EmployeeDayOffDTO>>(dayOffs);
                return Ok(dayOffs);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateCompany(UpdateCompanyDTO companyDTO) //teste edildi
        {
            try
            {
                Company company = mapper.Map<UpdateCompanyDTO, Company>(companyDTO);
                await companyService.UpdateCompany(company);
                return Ok(mapper.Map<Company, CompanyDTO>(company));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
