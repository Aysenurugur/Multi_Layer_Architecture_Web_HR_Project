using Core.Entities;
using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.BirthDate)
                .HasColumnType("datetime2");

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.HasIndex(x => x.PhoneNumber)
                .IsUnique();

            builder.HasOne(x => x.Company)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CompanyID);

            builder.HasMany<Debit>(x => x.Debits)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            builder.HasMany<Expense>(x => x.Expenses)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            builder.HasMany<File>(x => x.Files)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            builder.HasMany<DayOff>(x => x.DayOffs)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            builder.HasMany<Shift>(x => x.Shifts)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            builder.HasMany<Break>(x => x.Breaks)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            builder.HasMany<VetoMessage>(x => x.VetoMessages)
                .WithOne(x => x.VetodByUser)
                .HasForeignKey(x => x.VetodBy);

            builder.HasMany<Notification>(x => x.Notifications)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            builder.HasMany<Promotion>(x => x.Promotions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            //builder.Ignore(x => x.AccessFailedCount);
            //builder.Ignore(x => x.ConcurrencyStamp);
            //builder.Ignore(x => x.EmailConfirmed);
            //builder.Ignore(x => x.LockoutEnabled);
            //builder.Ignore(x => x.LockoutEnd);
            //builder.Ignore(x => x.NormalizedUserName);
            //builder.Ignore(x => x.PhoneNumberConfirmed);
            //builder.Ignore(x => x.UserName);
        }
    }
}
