using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Services;
using System;
using System.Collections.Generic;
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

        public async Task<Notification> CreateNotificationAsync(Notification newNotification)
        {
            await unitOfWork.Notification.AddAsync(newNotification);
            await unitOfWork.CommitAsync();
            return newNotification;
        }

        public async Task<Notification> GetNotificationByIdAsync(Guid id)
        {
            return await unitOfWork.Notification.GetByIDAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserIdAsync(Guid userId)
        {
            return await Task.FromResult(unitOfWork.Notification.List(x => x.UserID == userId && !x.IsSeen));
        }

        public async Task ReadNotificationAsync(Guid notificationId)
        {
            Notification notification = await GetNotificationByIdAsync(notificationId);
            notification.IsSeen = true;
            await unitOfWork.CommitAsync();
        }
    }
}
