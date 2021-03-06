using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDebitService
    {
        Task<IEnumerable<Debit>> GetAllDebits();
        Task<Debit> GetDebitById(Guid id);
        Task<Debit> CreateDebit(Debit newDebit);
        Task<bool> SetDebitStatus(Guid id, bool status);
        IEnumerable<Debit> GetDebitsByEmployeeId(Guid employeeId);
    }
}
