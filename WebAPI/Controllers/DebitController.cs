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
    public class DebitController : ControllerBase
    {
        private readonly IDebitService debitService;
        IMapper mapper;
        public DebitController(IDebitService _debitService, IMapper mapper)
        {
            this.debitService = _debitService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetDebitsByEmployeeId(Guid id) // test edildi
        {
            try
            {
                var debits = mapper.Map<IEnumerable<Debit>, IEnumerable<DebitDTO>>(debitService.GetDebitsByEmployeeId(id));
                return Ok(debits);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(DebitDTO debitDTO) //test edildi
        {
            try
            {
                Debit debit = mapper.Map<DebitDTO, Debit>(debitDTO);
                debit.CreatedDate = DateTime.Now;
                debit.IsApproved = false;
                DebitDTO newDebit = mapper.Map<Debit, DebitDTO>(await debitService.CreateDebit(debit));

                return Ok(newDebit);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> SetDebitStatus(DebitDTO debitDTO) //test edildi
        {
            try
            {
                await debitService.SetDebitStatus(debitDTO.DebitID, (bool)debitDTO.IsApproved);
                return Ok(debitDTO.IsApproved);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
