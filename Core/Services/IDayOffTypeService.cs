using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDayOffTypeService
    {
     
        Task<IEnumerable<DayOffType>> GetAllDayOffTypes();
        Task<DayOffType> CreateDayOffType(DayOffType newDayOfftype);
        Task<DayOffType> GetDayOffById(Guid id);
    }
}
