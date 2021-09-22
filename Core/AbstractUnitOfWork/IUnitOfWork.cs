using Core.AbstractRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AbstractUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBreakRepository Break { get; }
        ICommentRepository Comment { get; }
        ICompanyRepository Company { get; }
        IDayOffRepository DayOff { get; }
        IDebitRepository Debit { get; }
        IExpenseRepository Expense { get; }
        INotificationRepository Notification { get; }
        IPromotionRepository Promotion { get; }
        IShiftRepository Shift { get; }
        IUserRepository User { get; }

        Task<int> CommitAsync();
    }

}
