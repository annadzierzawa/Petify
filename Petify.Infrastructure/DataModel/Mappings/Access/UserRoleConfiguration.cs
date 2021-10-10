using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Domain.Access;

namespace SRW_CRM.Infrastructure.DataModel.Mappings.Access
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole", "Access");
            builder.HasKey(e => new { e.UserId, e.RoleId });
        }
    }
}
