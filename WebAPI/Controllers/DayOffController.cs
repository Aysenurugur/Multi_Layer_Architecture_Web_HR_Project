using AutoMapper;
using Core.Entities;
using Core.Services;
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
    public class DayOffController : ControllerBase
    {
        private readonly IDayOffService dayOffService;
        private readonly IMapper mapper;

        public DayOffController(IDayOffService dayOffService, IMapper mapper)
        {
            this.dayOffService = dayOffService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDayOffs() //Kontrol edildi.
        {
            try
            {
                IEnumerable<DayOff> dayOffs = await dayOffService.GetAllDayOffs();
                IEnumerable<DayOffDTO> dayOffDTO = mapper.Map<IEnumerable<DayOff>, IEnumerable<DayOffDTO>>(dayOffs);
                return Ok(dayOffDTO);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDayOffsByUserId(Guid userId)
        {
            
                IEnumerable<DayOff> dayOffs = await dayOffService.GetDayOffsByUserId(userId);
                IEnumerable<DayOffDTO> dayOffDTO = mapper.Map<IEnumerable<DayOff>, IEnumerable<DayOffDTO>>(dayOffs);
                return Ok(dayOffDTO);
          
        }

        [HttpPost]
        public async Task<IActionResult> CreateDayOff(DayOffDTO dayOffDTO) //test edildi.
        {
            try
            {
                dayOffDTO.DayOffID = Guid.NewGuid();
                var dayOffToCreate = mapper.Map<DayOffDTO, DayOff>(dayOffDTO);
                await dayOffService.CreateDayOff(dayOffToCreate);
                DayOffDTO dayOffResource = mapper.Map<DayOff, DayOffDTO>(dayOffToCreate);
                return Ok(dayOffResource);
            }
            catch (Exception)
            {

                return BadRequest();
            }
                
            

        }
    }
}
