using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDayOffService
    {
        Task<IEnumerable<DayOff>> GetAllDayOffs();
        Task<DayOff> GetDayOffById(Guid id);
        Task<DayOff> CreateDayOff(DayOff newDayOff);
        Task UpdateDayOff(DayOff dayOff);
        Task DeleteDayOff(DayOff dayOff);
    }
}
