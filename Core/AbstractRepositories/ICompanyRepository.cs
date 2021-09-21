using Core.AbstractRepositories.Generic;
using Core.Entities;
using Core.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface ICompanyRepository : ICrudRepository<Company>
    {
        Task<IEnumerable<DayOff>> GetDayOffsAsync(int dayOffTypeID);
        Task<IEnumerable<Expense>> GetExpensesAsync(int expenseID);
        Task<int> CountCompaniesAsync(int companyID);
        Task<IEnumerable<User>> GetEmployeeListAsync(int companyID, out int employeeCount);
        Task<IEnumerable<User>> GetManagerListAsync(int companyID, out int managerCount);

    }
}
