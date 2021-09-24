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
            return newBreak;
        }

        public async Task DeleteBreak(Break _break)
        {
            unitOfWork.Break.RemoveAsync(_break);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Break>> GetAllBreaks()
        {
            return await unitOfWork.Break.GetAllAsync();
        }

        public async Task<Break> GetBreakById(string id)
        {
            return await unitOfWork.Break.GetByIDAsync(id);
        }

        public async Task UpdateBreak(Break breakToBeUpdated, Break _break)
        {
            breakToBeUpdated.BreakID = _break.BreakID;
            await unitOfWork.CommitAsync();
        }
    }
}
