using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractRepositories.Generic
{
    public interface IListRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllByUserIDAsync(string id);
    }
}
