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
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork unitOfWork;

        public NotificationService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Notification> CreateNotification(Notification newNotification)
        {
            await unitOfWork.Notification.AddAsync(newNotification);
            return newNotification;
        }

        public async Task DeleteNotification(Notification notification)
        {
            unitOfWork.Notification.RemoveAsync(notification);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await unitOfWork.Notification.GetAllAsync();
        }

        public async Task<Notification> GetNotificationById(string id)
        {
            return await unitOfWork.Notification.GetByIDAsync(id);
        }

        public async Task UpdateNotification(Notification notificationToBeUpdated, Notification notification)
        {
            notificationToBeUpdated.NotificationID = notification.NotificationID;
            await unitOfWork.CommitAsync();
        }
    }
}
