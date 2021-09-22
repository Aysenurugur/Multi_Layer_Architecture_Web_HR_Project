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
    class DayOffMapping : IEntityTypeConfiguration<DayOff>
    {
        public void Configure(EntityTypeBuilder<DayOff> builder)
        {
            builder.HasKey(x => x.DayOffID);

            builder.Property(x => x.DayOffID)
                .UseIdentityColumn();

            builder.Property(x => x.IsApproved)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasOne(x => x.DayOffType)
                .WithMany(x => x.DayOffs)
                .HasForeignKey(x => x.DayOffTypeID);

            builder.HasOne(x => x.VetoMessage)
                .WithOne(x => x.DayOff)
                .HasForeignKey<DayOff>(x => x.VetoMessageID);
        }
    }
}
