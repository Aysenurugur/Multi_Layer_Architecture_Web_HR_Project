using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBreakService
    {
        Task<IEnumerable<Break>> GetAllBreaks();
        Task<Break> GetBreakById(Guid id);
        Task<Break> CreateBreak(Break newBreak);
        Task UpdateBreak(Break _break);
        Task<IEnumerable<Break>> GetBreaksByUserId(Guid UserId);
    }
}
