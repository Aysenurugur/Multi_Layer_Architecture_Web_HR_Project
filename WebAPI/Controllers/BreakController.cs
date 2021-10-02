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
        public async Task<IActionResult> GetBreaks()
        {
            try
            {
                var breaks = await breakService.GetAllBreaks();
                var breakDTO = mapper.Map<IEnumerable<Break>, IEnumerable<BreakDTO>>(breaks);
                return Ok(breakDTO);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetBreaksByUserId(Guid userId)
        //{
        //    try
        //    {
        //        var _breaks = breakService.GetBreaksByUserId(userId);
        //        var breakDTO = mapper.Map<IEnumerable<Break>, IEnumerable<BreakDTO>>(_breaks);
        //        return Ok(breakDTO);
        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest();
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CreateBreak(BreakDTO breakDTO)
        {
            try
            {
                breakDTO.BreakID= Guid.NewGuid();
                var breakToCreate = mapper.Map<BreakDTO, Break>(breakDTO);
                var newbreak = await breakService.CreateBreak(breakToCreate);
                var _break = await breakService.GetBreakById(newbreak.BreakID);
                var breakResource = mapper.Map<Break, BreakDTO>(_break);
                return Ok(breakResource);
            }
            catch (Exception)
            {

                return BadRequest();
            }


        }
    }
}
