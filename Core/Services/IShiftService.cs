using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IShiftService
    {
        Task<IEnumerable<Shift>> GetAllShifts();
        Task<Shift> GetShiftById(string id);
        Task<Shift> CreateShift(Shift newShift);
        Task UpdateShift(Shift shiftToBeUpdated, Shift shift);
        Task DeleteShift(Shift shift);
    }
}
