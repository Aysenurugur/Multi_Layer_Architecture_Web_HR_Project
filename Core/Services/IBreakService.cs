using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBreakService
    {
        Task<IEnumerable<Break>> GetAllBreaks();
        Task<Break> GetBreakById(string id);
        Task<Break> CreateBreak(Break newBreak);
        Task UpdateBreak(Break breakToBeUpdated, Break _break);
        Task DeleteBreak(Break _break);
    }
}
