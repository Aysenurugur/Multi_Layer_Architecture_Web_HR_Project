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
    class FileMapping : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(x => x.FileID);

            builder.Property(x => x.FileID)
                .UseIdentityColumn();

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(x => x.PDFFile)
                .IsRequired();

            builder.HasOne(x => x.FileType)
                .WithMany(x => x.Files)
                .HasForeignKey(x => x.FileTypeID);
        }
    }
}
