using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Common.Auth.Access.Lookups;
using Petify.Domain.Access;

namespace Petify.Infrastructure.DataModel.Mappings.Access
{
    public class RoleActionConfiguration : IEntityTypeConfiguration<RoleAction>
    {
        public void Configure(EntityTypeBuilder<RoleAction> builder)
        {
            builder.ToTable("RoleAction", "Access");
            builder.HasKey(e => new { e.RoleId, e.ActionId });
            builder.Property(e => e.Level).IsRequired();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<RoleAction> builder)
        {
            builder.HasData(new RoleAction { RoleId = (int)Roles.Admin, ActionId = (int)Actions.ManageUsers, Level = AccessLevel.Full.Id });
            builder.HasData(new RoleAction { RoleId = (int)Roles.Admin, ActionId = (int)Actions.ManageUsersAdvertisements, Level = AccessLevel.Full.Id });
            builder.HasData(new RoleAction { RoleId = (int)Roles.Admin, ActionId = (int)Actions.ManageMyAdvertisements, Level = AccessLevel.Full.Id });
            builder.HasData(new RoleAction { RoleId = (int)Roles.Admin, ActionId = (int)Actions.ManageMyPets, Level = AccessLevel.Full.Id });

            builder.HasData(new RoleAction { RoleId = (int)Roles.RegularUser, ActionId = (int)Actions.ManageMyAdvertisements, Level = AccessLevel.Full.Id });
            builder.HasData(new RoleAction { RoleId = (int)Roles.RegularUser, ActionId = (int)Actions.ManageMyPets, Level = AccessLevel.Full.Id });
        }
    }
}
