using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Entities.Identity;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<DayOff> GetDayOffById(Guid id)
        {
            return await unitOfWork.DayOff.GetByIDAsync(id);
        }

        public async Task<IEnumerable<DayOff>> GetAllDayOffs()
        {
            return await unitOfWork.DayOff.GetAllAsync();
        }

        public async Task<bool> SetDayOffStatus(Guid id, bool status)
        {
            DayOff dayOff = await unitOfWork.DayOff.GetByIDAsync(id);
            dayOff.IsApproved = status;
            unitOfWork.DayOff.Update(dayOff);
            bool check = await unitOfWork.CommitAsync() > 0;
            return await Task.FromResult(check);
        }

        public async Task<IEnumerable<DayOff>> GetDayOffsByCompany(Guid companyId)
        {
            List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId);
            List<DayOff> dayOffs = new List<DayOff>();
            foreach (User item in employees)
            {
                dayOffs.AddRange(item.DayOffs);
            }
            return await Task.FromResult(dayOffs);
        }

        public async Task<IEnumerable<DayOff>> WaitingApprovementDayOffs(Guid companyId)
        {
            List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId);
            List<DayOff> dayOffs = new List<DayOff>();
            foreach (User item in employees)
            {
                dayOffs.AddRange(item.DayOffs.Where(x => x.IsApproved == null));

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
