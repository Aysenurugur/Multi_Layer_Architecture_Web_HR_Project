using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPromotionService
    {
        Task<IEnumerable<Promotion>> GetAllPromotions();
        Task<Promotion> GetPromotionById(Guid id);
        Task<Promotion> CreatePromotion(Promotion newPromotion);
        Task UpdatePromotion(Promotion promotion);
    }
}
