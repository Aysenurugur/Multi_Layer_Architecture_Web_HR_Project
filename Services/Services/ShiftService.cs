using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IUnitOfWork unitOfWork;

        public ShiftService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Shift> CreateShiftAsync(Shift newShift)
        {
            await unitOfWork.Shift.AddAsync(newShift);
            await unitOfWork.CommitAsync();
            return newShift;
        }

        public async Task<IEnumerable<Shift>> GetAllShiftsAsync()
        {
            return await unitOfWork.Shift.GetAllAsync();
        }

        public async Task<Shift> GetShiftByIdAsync(Guid id)
        {
            return await unitOfWork.Shift.GetByIDAsync(id);
        }

        public async Task UpdateShiftAsync(Shift shift)
        {
            unitOfWork.Shift.Update(shift);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Shift>> GetShiftsByUserIdAsync(Guid userId)
        {
            List<Shift> shift = unitOfWork.Shift.List(x => x.UserID == userId).ToList();
            return await Task.FromResult(shift);

        }


    }
}