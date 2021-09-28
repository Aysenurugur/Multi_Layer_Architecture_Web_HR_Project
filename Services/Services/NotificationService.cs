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

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await unitOfWork.Notification.GetAllAsync();
        }

        public async Task<Notification> GetNotificationById(Guid id)
        {
            return await unitOfWork.Notification.GetByIDAsync(id);
        }

        public Task<IEnumerable<Notification>> GetNotificationsByUserId(Guid userId)
        {
            return Task.FromResult(unitOfWork.Notification.List(x => x.UserID == userId));
        }
    }
}
