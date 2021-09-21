using Core.AbstractRepositories.Generic;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IExpenseRepository : ICrudRepository<Expense>, IApprovementRepository<Expense>, IListRepository<Expense>
    {
    }
}
