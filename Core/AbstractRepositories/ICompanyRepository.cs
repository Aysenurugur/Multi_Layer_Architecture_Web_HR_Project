using Core.AbstractRepositories.Generic;
using Core.Entities;
using Core.Entities.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface ICompanyRepository : ICrudRepository<Company>
    {
        Task<int> CountCompaniesAsync();
        IEnumerable<User> GetEmployeeListAsync(int companyID, out int employeeCount);

    }
}
