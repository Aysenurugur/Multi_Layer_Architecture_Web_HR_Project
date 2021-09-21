using Core.AbstractRepositories.Generic;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IFileRepository : ICrudRepository<File>, IListRepository<File>
    {
    }
}
