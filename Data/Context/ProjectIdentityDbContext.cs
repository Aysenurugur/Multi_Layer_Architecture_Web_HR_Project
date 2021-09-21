using Data.Entities;
using Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ProjectIdentityDbContext : IdentityDbContext<User, IdentityRole, string>
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
            base.OnModelCreating(builder);
        }

    }
}
