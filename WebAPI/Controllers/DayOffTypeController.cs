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
    public class DayOffTypeController : ControllerBase
    {
        private readonly IDayOffTypeService dayOffTypeService;
        private readonly IMapper mapper;

        public DayOffTypeController(IDayOffTypeService dayOffTypeService, IMapper mapper)
        {
            this.dayOffTypeService = dayOffTypeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDayOffTypes() //Kontrol edildi.

        {
            try
            {
                var dayOffTypes = await dayOffTypeService.GetAllDayOffTypes();
                var dayOffTypeDTO = mapper.Map<IEnumerable<DayOffType>, IEnumerable<DayOffTypeDTO>>(dayOffTypes);
                return Ok(dayOffTypeDTO);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateDayOffType(DayOffTypeDTO dayOffTypeDTO) //Kontrol edildi.

        {
            
                dayOffTypeDTO.DayOffTypeID = Guid.NewGuid();
                var dayOffTypeToCreate = mapper.Map<DayOffTypeDTO, DayOffType>(dayOffTypeDTO);
                dayOffTypeToCreate.CreatedDate = DateTime.Now;
                var newDayOffType = await dayOffTypeService.CreateDayOffType(dayOffTypeToCreate);
                var dayOffType = await dayOffTypeService.GetDayOffById(newDayOffType.DayOffTypeID);
                var dayOffTypeResource = mapper.Map<DayOffType, DayOffTypeDTO>(dayOffType);
                return Ok(dayOffTypeResource);
            
        }
    }
}
