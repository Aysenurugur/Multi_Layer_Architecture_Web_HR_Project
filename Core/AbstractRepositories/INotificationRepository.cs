using Core.AbstractRepositories.Generic;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface INotificationRepository : ICrudRepository<Notification>, IListRepository<Notification>
    {
        Task<bool> ReadNotifications(List<Notification> notifications);
    }
}
