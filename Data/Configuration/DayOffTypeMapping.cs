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
    class DayOffTypeMapping : IEntityTypeConfiguration<DayOffType>
    {
        public void Configure(EntityTypeBuilder<DayOffType> builder)
        {
            builder.HasKey(x => x.DayOffTypeID);

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(x => x.Duration)
                .IsRequired();

            builder.Property(x => x.Content)
                .IsRequired();
        }
    }
}
