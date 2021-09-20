using Data.Entities;
using System.Threading.Tasks;

namespace Core.AbstractRepositories.Generic
{
    public interface IApprovementRepository<TEntity> where TEntity : class
    {
        Task SetStatusAsync(int id, bool status);
        Task SendVetoMessageAsync(VetoMessage vetoMessage, string userID); //private yapılabilir
        //Task<bool> DisApproveAsync(TEntity entity);
    }
}
