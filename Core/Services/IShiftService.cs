using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IShiftService
    {
        Task<IEnumerable<Shift>> GetAllShiftsAsync();
        Task<Shift> GetShiftByIdAsync(Guid id);
        Task<Shift> CreateShiftAsync(Shift newShift);
        Task UpdateShiftAsync(Shift shift);
        Task<IEnumerable<Shift>> GetShiftsByUserIdAsync(Guid userId);
    }
}
