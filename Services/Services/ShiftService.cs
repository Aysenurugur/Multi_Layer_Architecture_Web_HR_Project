﻿using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Shift> CreateShift(Shift newShift)
        {
            await unitOfWork.Shift.AddAsync(newShift);
            return newShift;
        }

        public async Task<IEnumerable<Shift>> GetAllShifts()
        {
            return await unitOfWork.Shift.GetAllAsync();
        }

        public async Task<Shift> GetShiftById(Guid id)
        {
            return await unitOfWork.Shift.GetByIDAsync(id);
        }

        public async Task UpdateShift(Shift shift)
        {
            unitOfWork.Shift.Update(shift);
            await unitOfWork.CommitAsync();
        }
    }
}
