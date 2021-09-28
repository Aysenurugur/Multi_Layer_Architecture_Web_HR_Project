using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork unitOfWork;
        public ExpenseService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Expense> CreateExpense(Expense expense)
        {
            await unitOfWork.Expense.AddAsync(expense);
            return expense;
        }

        public async Task<Expense> GetExpenseById(Guid id)
        {
            return await unitOfWork.Expense.GetByIDAsync(id);
        }

        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return await unitOfWork.Expense.GetAllAsync();
        }

        public async Task UpdateExpense(Expense expense)
        {
            unitOfWork.Expense.Update(expense);
            await unitOfWork.CommitAsync();
        }

        public Task<Expense> GetExpenseById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
