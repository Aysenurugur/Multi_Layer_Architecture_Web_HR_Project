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
    public class VetoMessageController : ControllerBase
    {
        IVetoMessageService vetoMessageService;
        IMapper mapper;
        public VetoMessageController(IVetoMessageService vetoMessageService, IMapper mapper)
        {
            this.vetoMessageService = vetoMessageService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVetoMessage(VetoMessageDTO vetoMessageDTO)
        {
            VetoMessage vetoMessage = mapper.Map<VetoMessageDTO, VetoMessage>(vetoMessageDTO);
            await vetoMessageService.CreateVetoMessageAsync(vetoMessage);
            return Ok(mapper.Map<VetoMessage, VetoMessageDTO>(vetoMessage));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserVetoMessages(Guid id)
        {
            IEnumerable<VetoMessage> vetoMessages = await vetoMessageService.GetVetoMessagesByUserId(id);
            IEnumerable<VetoMessageDTO> vetoMessageDTOs = mapper.Map<IEnumerable<VetoMessage>, IEnumerable<VetoMessageDTO>>(vetoMessages);
            return Ok(vetoMessageDTOs);
        }
    }
}
