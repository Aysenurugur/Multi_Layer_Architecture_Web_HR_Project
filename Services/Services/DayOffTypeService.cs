using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Services;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DayOffTypeService : IDayOffTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        public DayOffTypeService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        public async Task<DayOffType> CreateDayOffType(DayOffType newDayOffType)
        {
            await unitOfWork.DayOffType.AddAsync(newDayOffType);
            await unitOfWork.CommitAsync();
            return newDayOffType;
        }

        public async Task<IEnumerable<DayOffType>> GetAllDayOffTypes()
        {
            return await unitOfWork.DayOffType.GetAllAsync();
        }

        public async Task<DayOffType> GetDayOffById(Guid id)
        {
            return await unitOfWork.DayOffType.GetByIDAsync(id);
        }
    }
}
