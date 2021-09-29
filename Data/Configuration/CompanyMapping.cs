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
    class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.CompanyID);

            builder.Property(x => x.ExpirationDate)
                .HasColumnType("datetime2");

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Address)
                .HasMaxLength(250);
        }
    }
}
