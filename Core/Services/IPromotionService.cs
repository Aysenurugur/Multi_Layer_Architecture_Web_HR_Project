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
        Task<IEnumerable<Promotion>> GetAllPromotionsAsync();
        Task<Promotion> GetPromotionByIdAsync(Guid id);
        Task<Promotion> CreatePromotionAsync(Promotion newPromotion);
        Task UpdatePromotionAsync(Promotion promotion);
        Task<IEnumerable<Promotion>> GetPromotionsByIserIdAsync(Guid userId);
    }
}
