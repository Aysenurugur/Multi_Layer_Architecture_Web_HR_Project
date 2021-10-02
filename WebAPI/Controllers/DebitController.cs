﻿using AutoMapper;
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
            var debits = mapper.Map<IEnumerable<Debit>, IEnumerable<DebitDTO>>(debitService.GetDebitsByEmployeeId(id));
            return Ok(debits);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DebitDTO debitDTO) //test edildi
        {
            Debit debit = mapper.Map<DebitDTO, Debit>(debitDTO);
            debit.CreatedDate = DateTime.Now;
            var newDebit = mapper.Map<Debit, DebitDTO>(await debitService.CreateDebit(debit));

            return Ok(newDebit);
        }
    }
}