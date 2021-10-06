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
            try
            {
                var expenses = expenseService.GetExpensesByEmployeeId(id);
                var expensesDTO = mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDTO>>(expenses);
                return Ok(expensesDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpensesByCompanyId(Guid id) //test edildi
        {
            try
            {
                IEnumerable<Expense> expenses = await expenseService.GetExpenseByCompanyId(id);
                IEnumerable<ExpenseDTO> expensesDTO = mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDTO>>(expenses);
                return Ok(expensesDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseDTO expenseDTO) //test edildi
        {
            try
            {
                expenseDTO.ExpenseId = Guid.NewGuid();
                Expense expenseToCreate = mapper.Map<ExpenseDTO, Expense>(expenseDTO);
                expenseToCreate.CreatedDate = DateTime.Now;
                Expense newExpense = await expenseService.CreateExpense(expenseToCreate);
                ExpenseDTO expenseResource = mapper.Map<Expense, ExpenseDTO>(newExpense);
                return Ok(expenseResource);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> SetExpenseStatus(ExpenseDTO expenseDTO) //test edildi
        {
            try
            {
                await expenseService.SetExpenseStatus(expenseDTO.ExpenseId, (bool)expenseDTO.IsApproved);
                return Ok(expenseDTO.IsApproved);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
