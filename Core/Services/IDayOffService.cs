using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDayOffService
    {
        Task<IEnumerable<DayOff>> GetAllDayOffs();
        Task<DayOff> GetDayOffById(Guid id);
        Task<DayOff> CreateDayOff(DayOff newDayOff);
        Task<IEnumerable<DayOff>> GetDayOffsByCompany(Guid companyId);
        Task<IEnumerable<DayOff>> WaitingApprovementDayOffs(Guid companyId);
        Task<bool> SetDayOffStatus(Guid id, bool status);
        IEnumerable<DayOff> GetDayOffsByUserId(Guid userId);
    }
}
