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
    public class DebitService : IDebitService
    {
        private readonly IUnitOfWork unitOfWork;
        public DebitService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Debit> CreateDebit(Debit newDebit)
        {
            await unitOfWork.Debit.AddAsync(newDebit);
            await unitOfWork.CommitAsync();
            return newDebit;
        }

        public async Task<Debit> GetDebitById(Guid id) 
        {
            return await unitOfWork.Debit.GetByIDAsync(id);
        }

        public async Task<IEnumerable<Debit>> GetAllDebits()
        {
            return await unitOfWork.Debit.GetAllAsync();
        }

        public async Task<bool> SetDebitStatus(Guid id, bool status)
        {
            Debit debit = await unitOfWork.Debit.GetByIDAsync(id);
            debit.IsApproved = status;
            unitOfWork.Debit.Update(debit);
            bool check = await unitOfWork.CommitAsync() > 0;
            return await Task.FromResult(check);
        }

        public IEnumerable<Debit> GetDebitsByEmployeeId(Guid employeeId)
        {
            return unitOfWork.Debit.List(x => x.UserID == employeeId);
        }
    }
}
