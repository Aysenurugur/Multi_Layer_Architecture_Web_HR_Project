using Data.Entities;
using System.Threading.Tasks;

namespace Core.AbstractRepositories.Generic
{
    public interface IApprovementRepository<TEntity> where TEntity : class
    {
        Task<bool> ApproveAsync(TEntity entity);
        Task<bool> DisApproveAsync(TEntity entity);
        Task SendVetoMessageAsync(VetoMessage vetoMessage, int userID);
    }
}
