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
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService shiftService;
        private readonly IMapper mapper;

        public ShiftController(IShiftService shiftService, IMapper mapper)
        {
            this.shiftService = shiftService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShiftsByUserId(Guid id) //test edildi
        {
            IEnumerable<Shift> shifts = await shiftService.GetShiftsByUserIdAsync(id);
            IEnumerable<ShiftDTO> shiftDTOs = mapper.Map<IEnumerable<Shift>, IEnumerable<ShiftDTO>>(shifts);
            return Ok(shiftDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShiftById(Guid id)
        {
            Shift shift = await shiftService.GetShiftByIdAsync(id);
            ShiftDTO shiftDTO = mapper.Map<Shift, ShiftDTO>(shift);
            return Ok(shiftDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShift(ShiftDTO shiftDTO) //test edildi
        {
            Shift shift = mapper.Map<ShiftDTO, Shift>(shiftDTO);
            await shiftService.CreateShiftAsync(shift);
            return Ok(mapper.Map<Shift, ShiftDTO>(shift));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShift(ShiftDTO shiftDTO) //test edildi
        {
            Shift shift = mapper.Map<ShiftDTO, Shift>(shiftDTO);
            await shiftService.UpdateShiftAsync(shift);
            return Ok(mapper.Map<Shift, ShiftDTO>(shift));
        }
    }
}
