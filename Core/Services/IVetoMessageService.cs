using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IVetoMessageService
    {
        Task CreateVetoMessageAsync(VetoMessage vetoMessage);
        Task<IEnumerable<VetoMessage>> GetVetoMessagesByUserId(Guid userId);
    }
}
