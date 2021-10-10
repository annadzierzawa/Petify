using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Common.Auth.Access.Lookups;
using Petify.Domain.Access;
using System;

namespace Petify.Infrastructure.DataModel.Mappings.Access
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", "Access");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Role> builder)
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                builder.HasData(new Role((int)role, RoleLookup.Descriptions[(int)role]));
            }
        }
    }
}
