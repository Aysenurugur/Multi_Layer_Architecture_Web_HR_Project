using Core.AbstractRepositories.Generic;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IExpenseRepository : ICrudRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetExpensesByCompanyAsync(Guid id);
    }
}
