using Core.AbstractRepositories.Generic;
using Core.Entities;

namespace Core.AbstractRepositories
{
    public interface IPromotionRepository : ICrudRepository<Promotion>, IListRepository<Promotion>
    {
    }
}
