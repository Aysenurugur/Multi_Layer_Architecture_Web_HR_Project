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
    class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.CommentID);

            builder.Property(x => x.CommentID)
                .UseIdentityColumn();

            builder.Property(x => x.CreatedDate)
                .HasColumnType("datetime2");

            builder.HasOne(x => x.Company)
                .WithOne(x => x.Comment)
                .HasForeignKey<Comment>(x => x.CompanyID);
        }
    }
}
