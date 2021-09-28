using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task<Notification> GetNotificationById(Guid id);
        Task<Notification> CreateNotification(Notification newNotification);
        Task<IEnumerable<Notification>> GetNotificationsByUserId(Guid userId);
    }
}
