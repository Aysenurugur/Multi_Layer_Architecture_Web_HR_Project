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
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService expenseService;
        private readonly IMapper mapper;
        public ExpenseController(IExpenseService _expenseService, IMapper _mapper)
        {
            this.expenseService = _expenseService;
            this.mapper = _mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetExpensesByEmployeeId(Guid id) //test edildi
        {
            var expenses = expenseService.GetExpensesByEmployeeId(id);
            var expensesDTO = mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDTO>>(expenses);
            return Ok(expensesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpensesByCompanyId(Guid id) //test edildi
        {
            var expenses = await expenseService.GetExpenseByCompanyId(id);
            var expensesDTO = mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDTO>>(expenses);
            return Ok(expensesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseDTO expenseDTO) //test edildi
        {
            expenseDTO.ExpenseId = Guid.NewGuid();
            var expenseToCreate = mapper.Map<ExpenseDTO, Expense>(expenseDTO);
            expenseToCreate.CreatedDate = DateTime.Now;
            var newExpense = await expenseService.CreateExpense(expenseToCreate);
            var expenseResource = mapper.Map<Expense, ExpenseDTO>(newExpense);
            return Ok(expenseResource);
        }
    }
}
