using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Entities.Identity;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DayOffService : IDayOffService
    {
        private readonly IUnitOfWork unitOfWork;
        public DayOffService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<DayOff> CreateDayOff(DayOff newDayOff)
        {
            await unitOfWork.DayOff.AddAsync(newDayOff);
            return newDayOff;
        }

        public async Task DeleteDayOff(DayOff dayOff)
        {
            unitOfWork.DayOff.RemoveAsync(dayOff);
            await unitOfWork.CommitAsync();
        }

        public async Task<DayOff> GetDayOffById(Guid id)
        {
            return await unitOfWork.DayOff.GetByIDAsync(id);
        }

        public async Task<IEnumerable<DayOff>> GetAllDayOffs()
        {
            return await unitOfWork.DayOff.GetAllAsync();
        }

        public async Task UpdateDayOff(DayOff dayOff)
        {
            dayOff.IsApproved = true;
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<DayOff>> GetDayOffsByDayOffType(Guid companyId)
        {
            List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId);
            List<DayOff> dayOffs = new List<DayOff>();
            foreach (User item in employees)
            {
                dayOffs.AddRange(item.DayOffs);
            }
            return await Task.FromResult(dayOffs);
        }

        //public async Task<IEnumerable<DayOff>> GetDayOffsByDayOffType(Guid companyId,Guid dayOffTypeId) //hem day off type a göre hem de verilen şirkete göre day off lar gelsin
        //{
        //    List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId);
        //    List<DayOff> dayOffs = new List<DayOff>();
        //    foreach (User item in employees)
        //    {
        //        foreach (DayOff dayOff in item.DayOffs)
        //        {
        //            if (dayOff.DayOffTypeID == dayOffTypeId) dayOffs.Add(dayOff);
        //        }
        //    }
        //    return await Task.FromResult(dayOffs);
        //} 

    }
}
