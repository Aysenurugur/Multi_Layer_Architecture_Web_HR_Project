using Core.AbstractRepositories.Generic;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IDebitRepository : ICrudRepository<Debit>, IApprovementRepository<Debit>, IListRepository<Debit>
    {

    }
}
