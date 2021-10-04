using Core.AbstractUnitOfWork;
using Core.Entities;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VetoMessageService : IVetoMessageService
    {
        IUnitOfWork unitOfWork;
        public VetoMessageService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateVetoMessageAsync(VetoMessage vetoMessage)
        {
            vetoMessage.CreatedDate = DateTime.Now;
            await unitOfWork.User.SendVetoMessageAsync(vetoMessage);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<VetoMessage>> GetVetoMessagesByUserId(Guid userId)
        {
            return await unitOfWork.User.GetUserVetoMessages(userId);
        }
    }
}
