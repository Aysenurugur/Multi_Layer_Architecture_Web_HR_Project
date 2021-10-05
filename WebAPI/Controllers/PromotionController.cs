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
        public async Task<IActionResult> GetPromotionsByUserIdAsync(Guid id)
        {
            IEnumerable<Promotion> promotions = await promotionService.GetPromotionsByIserIdAsync(id);
            IEnumerable<PromotionDTO> promotionDTOs = mapper.Map<IEnumerable<Promotion>, IEnumerable<PromotionDTO>>(promotions);
            return Ok(promotionDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> AddPromotionAsync(PromotionDTO promotionDTO)
        {
            Promotion promotion = mapper.Map<PromotionDTO, Promotion>(promotionDTO);
            Promotion promotionToBeCreated = await promotionService.CreatePromotionAsync(promotion);
            PromotionDTO createdPromotionDTO = mapper.Map<Promotion, PromotionDTO>(promotionToBeCreated);
            return Ok(createdPromotionDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotionByIdAsync(Guid id)
        {
            Promotion promotion = await promotionService.GetPromotionByIdAsync(id);
            PromotionDTO promotionDTO = mapper.Map<Promotion, PromotionDTO>(promotion);
            return Ok(promotionDTO);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePromotionAsync(PromotionDTO promotionDTO)
        {
            Promotion promotion = await promotionService.GetPromotionByIdAsync(promotionDTO.PromotionID);
            Promotion promotionToBeUpdated = mapper.Map(promotionDTO, promotion);
            await promotionService.UpdatePromotionAsync(promotionToBeUpdated);
            return Ok(mapper.Map<Promotion, PromotionDTO>(promotionToBeUpdated));
        }
    }
}
