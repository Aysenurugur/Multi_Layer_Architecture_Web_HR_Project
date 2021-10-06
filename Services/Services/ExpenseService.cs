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
            await unitOfWork.CommitAsync();
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

        public async Task<bool> SetExpenseStatus(Guid id, bool status)
        {
            Expense expense = await unitOfWork.Expense.GetByIDAsync(id);
            expense.IsApproved = status;
            bool check = await unitOfWork.CommitAsync() > 0;
            return await Task.FromResult(check);
        }

        public IEnumerable<Expense> GetExpensesByEmployeeId(Guid employeeId)
        {
            return unitOfWork.Expense.List(x => x.UserID == employeeId);
        }

        public async Task<IEnumerable<Expense>> GetExpenseByCompanyId(Guid companyId)
        {
            return await unitOfWork.Expense.GetExpensesByCompanyAsync(companyId);
        }
    }
}
