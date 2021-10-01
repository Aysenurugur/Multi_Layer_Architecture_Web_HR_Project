using Core.AbstractRepositories;
using Core.AbstractRepositories.Generic;
using Core.AbstractUnitOfWork;
using Data.Context;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectIdentityDbContext context;
        private BreakRepository BreakRepository;
        private CommentRepository CommentRepository;
        private CompanyRepository CompanyRepository;
        private DayOffRepository DayOffRepository;
        private DayOffTypeRepository DayOffTypeRepository;
        private DebitRepository DebitRepository;
        private ExpenseRepository ExpenseRepository;
        private NotificationRepository NotificationRepository;
        private PromotionRepository PromotionRepository;
        private ShiftRepository ShiftRepository;
        private UserRepository UserRepository;
        private FileRepository FileRepository;
        private FileTypeRepository FileTypeRepository;
        public UnitOfWork(ProjectIdentityDbContext context)
        {
            this.context = context;
        }

        public IBreakRepository Break => BreakRepository = BreakRepository ?? new BreakRepository(context);
        public ICommentRepository Comment => CommentRepository = CommentRepository ?? new CommentRepository(context);
        public ICompanyRepository Company => CompanyRepository = CompanyRepository ?? new CompanyRepository(context);
        public IDayOffRepository DayOff => DayOffRepository = DayOffRepository ?? new DayOffRepository(context);
        public IDayOffTypeRepository DayOffType => DayOffTypeRepository = DayOffTypeRepository ?? new DayOffTypeRepository(context);
        public IDebitRepository Debit => DebitRepository = DebitRepository ?? new DebitRepository(context);
        public IExpenseRepository Expense => ExpenseRepository = ExpenseRepository ?? new ExpenseRepository(context);
        public INotificationRepository Notification => NotificationRepository = NotificationRepository ?? new NotificationRepository(context);
        public IPromotionRepository Promotion => PromotionRepository = PromotionRepository ?? new PromotionRepository(context);
        public IShiftRepository Shift => ShiftRepository = ShiftRepository ?? new ShiftRepository(context);
        public IUserRepository User => UserRepository = UserRepository ?? new UserRepository(context);

        public IFileRepository File => FileRepository = FileRepository ?? new FileRepository(context);
        public IFileTypeRepository FileType => FileTypeRepository = FileTypeRepository ?? new FileTypeRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
