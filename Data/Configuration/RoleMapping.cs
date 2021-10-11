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
    class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
            new Role()
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new Role()
            {
                Id = Guid.NewGuid(),
                Name = "Manager",
                NormalizedName = "MANAGER"
            },
            new Role()
            {
                Id = Guid.NewGuid(),
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            });
        }
    }
}
