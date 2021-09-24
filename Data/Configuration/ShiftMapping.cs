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
    class ShiftMapping : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasKey(x => x.ShiftID);

            builder.Property(x => x.BeginDate)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(x => x.EndDate)
                .HasColumnType("datetime2")
                .IsRequired();
        }
    }
}
