using Core.AbstractRepositories.Generic;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IDayOffRepository : ICrudRepository<DayOff> , IApprovementRepository<DayOff>, IListRepository<DayOff>
    {
    }
}
