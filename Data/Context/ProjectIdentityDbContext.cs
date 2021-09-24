using Core.Entities;
using Core.Entities.Identity;
using Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Context
{
    public class ProjectIdentityDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ProjectIdentityDbContext(DbContextOptions<ProjectIdentityDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Break> Breaks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DayOff> DayOffs { get; set; }
        public DbSet<DayOffType> DayOffTypes { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<VetoMessage> VetoMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BreakMapping());
            builder.ApplyConfiguration(new CommentMapping());
            builder.ApplyConfiguration(new CompanyMapping());
            builder.ApplyConfiguration(new DayOffMapping());
            builder.ApplyConfiguration(new DayOffTypeMapping());
            builder.ApplyConfiguration(new DebitMapping());
            builder.ApplyConfiguration(new ExpenseMapping());
            builder.ApplyConfiguration(new FileMapping());
            builder.ApplyConfiguration(new FileTypeMapping());
            builder.ApplyConfiguration(new NotificationMapping());
            builder.ApplyConfiguration(new PromotionMapping());
            builder.ApplyConfiguration(new RoleMapping());
            builder.ApplyConfiguration(new ShiftMapping());
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new VetoMessageMapping());

            base.OnModelCreating(builder);
        }

    }
}
