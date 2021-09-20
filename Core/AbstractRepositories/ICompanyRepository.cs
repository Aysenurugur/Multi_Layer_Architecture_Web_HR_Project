using Core.AbstractRepositories.Generic;
using Data.Entities;
using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface ICompanyRepository: ICrudRepository<Company>
    {
        Task<IEnumerable<Company>> GetDayOffsAsync(int DayOffTypeID);
        Task<IEnumerable<Company>> GetExpensesAsync(int ExpenseID);
        Task<Company> CountCompaniesAsync(int companyID);
        Task<IEnumerable<User>> GetEmployeeListAsync(int companyID, out int employeeCount);
        Task<IEnumerable<User>> GetManagerListAsync(int companyID, out int managerCount);
      
    }
}
