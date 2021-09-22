using Core.AbstractRepositories;
using Core.Entities;
using Core.Entities.Identity;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class NotificationRepository : CrudRepository<Notification> , INotificationRepository
    {
        public NotificationRepository(ProjectIdentityDbContext context) : base(context)
        {
        }

        private ProjectIdentityDbContext DbContext
        {
            get { return context as ProjectIdentityDbContext; }
        }

       // Her bir üye tipi için bildirimler sayfası eklenebilir.Bildirimler sayfasında kendisine gelen talepler görüntülenebilir ve yönetilebilir.
       //izin talep


       

    }
}
