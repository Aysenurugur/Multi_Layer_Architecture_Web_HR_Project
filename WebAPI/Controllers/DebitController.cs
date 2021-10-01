using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DebitController : ControllerBase
    {
        private readonly IDebitService debitService;
        public DebitController(IDebitService _debitService)
        {
            this.debitService = _debitService;
        }

        [HttpGet("{id}")]
        public IActionResult GetDebitsByEmployeeId(Guid id) // test edildi
        {
            var debits = debitService.GetDebitsByEmployeeId(id);
            return Ok(debits);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Debit debit) //test edildi
        {
            debit.DebitID = Guid.NewGuid(); // bunları service tarafında yazsak sanki daha mı mantıklı ?? 
            debit.CreatedDate = DateTime.Now;
            var newDebit =await debitService.CreateDebit(debit);
            return Ok(newDebit);
        }
    }
}
