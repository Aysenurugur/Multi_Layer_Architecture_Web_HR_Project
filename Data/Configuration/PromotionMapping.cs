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
    class PromotionMapping : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasKey(x => x.PromotionID);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(x => x.Title)
                .IsRequired();
        }
    }
}
