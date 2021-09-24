using Core.AbstractUnitOfWork;
using Core.Entities;
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
            return newDebit;
        }

        public async Task DeleteDebit(Debit debit)
        {
            unitOfWork.Debit.RemoveAsync(debit);
            await unitOfWork.CommitAsync();
        }

        public async Task<Debit> GetDebitById(Guid id)
        {
            return await unitOfWork.Debit.GetByIDAsync(id);
        }

        public async Task<IEnumerable<Debit>> GetAllDebits()
        {
            return await unitOfWork.Debit.GetAllAsync();
        }

        public async Task UpdateDebit(Debit debit)
        {
            debit.IsApproved = true;
            await unitOfWork.CommitAsync();
        }
    }
}
