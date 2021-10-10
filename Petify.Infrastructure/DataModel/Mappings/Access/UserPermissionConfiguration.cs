using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Domain.Access;

namespace Petify.Infrastructure.DataModel.Mappings.Access
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToView("VW_UserPermissions", "Access");
            builder.HasNoKey();
        }
    }
}
