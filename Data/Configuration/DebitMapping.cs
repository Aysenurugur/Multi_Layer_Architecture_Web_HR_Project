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
    class DebitMapping : IEntityTypeConfiguration<Debit>
    {
        public void Configure(EntityTypeBuilder<Debit> builder)
        {
            builder.HasKey(x => x.DebitID);

            builder.Property(x => x.IsApproved)
                .IsRequired(false);
        }
    }
}
