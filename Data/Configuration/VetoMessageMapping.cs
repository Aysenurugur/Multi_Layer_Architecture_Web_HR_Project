using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class VetoMessageMapping : IEntityTypeConfiguration<VetoMessage>
    {
        public void Configure(EntityTypeBuilder<VetoMessage> builder)
        {
            builder.HasKey(x => x.VetoMessageID);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired();

            builder.HasOne(x => x.DayOff)
                .WithOne(x => x.VetoMessage)
                .HasForeignKey<VetoMessage>(x => x.DayOffID)
                .IsRequired(false);

            builder.HasOne(x => x.Debit)
                .WithOne(x => x.VetoMessage)
                .HasForeignKey<VetoMessage>(x => x.DebitID)
                .IsRequired(false);

            builder.HasOne(x => x.Expense)
                .WithOne(x => x.VetoMessage)
                .HasForeignKey<VetoMessage>(x => x.ExpenseID)
                .IsRequired(false);
        }
    }
}
