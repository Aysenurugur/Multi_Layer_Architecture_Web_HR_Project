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
    public class PromotionController : ControllerBase
    {
        IPromotionService promotionService;
        IMapper mapper;

        public PromotionController(IPromotionService promotionService, IMapper mapper)
        {
            this.promotionService = promotionService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotionsByUserId(Guid id)
        {
            IEnumerable<Promotion> promotions = await promotionService.GetPromotionsByIserIdAsync(id);
            IEnumerable<PromotionDTO> promotionDTOs = mapper.Map<IEnumerable<Promotion>, IEnumerable<PromotionDTO>>(promotions);
            return Ok(promotionDTOs);
        }
    }
}
