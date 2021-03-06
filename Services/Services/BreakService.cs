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
    public class BreakService : IBreakService
    {
        private readonly IUnitOfWork unitOfWork;

        public BreakService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        public async Task<Break> CreateBreak(Break newBreak)
        {
            await unitOfWork.Break.AddAsync(newBreak);
            await unitOfWork.CommitAsync();
            return newBreak;
        }

        public async Task<IEnumerable<Break>> GetAllBreaks()
        {
            return await unitOfWork.Break.GetAllAsync();
        }

        public async Task<Break> GetBreakById(Guid id)
        {
            return await unitOfWork.Break.GetByIDAsync(id);
        }

        public async Task UpdateBreak(Break _break)
        {
            unitOfWork.Break.Update(_break);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Break>> GetBreaksByUserId(Guid UserId)
        {
            List<Break> breaks = unitOfWork.Break.List(x => x.UserID == UserId).ToList();
            return await Task.FromResult(breaks);

        }
    }
}
