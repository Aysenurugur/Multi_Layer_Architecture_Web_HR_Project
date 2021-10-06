using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface INotificationService
    {
        Task<Notification> GetNotificationByIdAsync(Guid id);
        Task<Notification> CreateNotificationAsync(Notification newNotification);
        Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(Guid userId);
        Task ReadNotificationAsync(Guid notificationId);
    }
}
