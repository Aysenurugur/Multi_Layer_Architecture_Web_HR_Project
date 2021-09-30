using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseById(Guid id);
        Task<Expense> CreateExpense(Expense expense);
        Task<bool> SetExpenseStatus(Guid id, bool status);
        IEnumerable<Expense> GetExpensesByEmployeeId(Guid employeeId);
        Task<IEnumerable<Expense>> GetExpenseByCompanyId(Guid companyId);
    }
}
