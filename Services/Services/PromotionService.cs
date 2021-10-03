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
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork unitOfWork;

        public PromotionService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Promotion> CreatePromotion(Promotion newPromotion)
        {
            await unitOfWork.Promotion.AddAsync(newPromotion);
            return newPromotion;
        }

        public async Task<IEnumerable<Promotion>> GetAllPromotions()
        {
            return await unitOfWork.Promotion.GetAllAsync();
        }

        public async Task<Promotion> GetPromotionById(Guid id)
        {
            return await unitOfWork.Promotion.GetByIDAsync(id);
        }

        public async Task UpdatePromotion(Promotion promotion)
        {
            unitOfWork.Promotion.Update(promotion);
            await unitOfWork.CommitAsync();
        }
    }
}
