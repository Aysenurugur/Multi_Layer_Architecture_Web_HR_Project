using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BreakController : ControllerBase
    {
        private readonly IBreakService breakService;
        private readonly IMapper mapper;

        public BreakController(IBreakService breakService, IMapper mapper)
        {
            this.breakService = breakService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBreaks() //test edildi
        {
            try
            {
                IEnumerable<Break> breaks = await breakService.GetAllBreaks();
                IEnumerable<BreakDTO> breakDTO = mapper.Map<IEnumerable<Break>, IEnumerable<BreakDTO>>(breaks);
                return Ok(breakDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreaksByUserId(Guid id) //test edildi
        {
            try
            {
                IEnumerable<Break> _breaks = await breakService.GetBreaksByUserId(id);
                IEnumerable<BreakDTO> breakDTO = mapper.Map<IEnumerable<Break>, IEnumerable<BreakDTO>>(_breaks);
                return Ok(breakDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreak(BreakDTO breakDTO) //test edildi
        {
            try
            {
                breakDTO.BreakID = Guid.NewGuid();
                Break breakToCreate = mapper.Map<BreakDTO, Break>(breakDTO);
                await breakService.CreateBreak(breakToCreate);
                BreakDTO breakResource = mapper.Map<Break, BreakDTO>(breakToCreate);
                return Ok(breakResource);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
