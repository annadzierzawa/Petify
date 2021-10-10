using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Domain.Access;

namespace Petify.Infrastructure.DataModel.Mappings.Access
{
    public class UserActionConfiguration : IEntityTypeConfiguration<UserAction>
    {
        public void Configure(EntityTypeBuilder<UserAction> builder)
        {
            builder.ToTable("UserAction", "Access");
            builder.HasKey(e => new { e.UserId, e.ActionId });
            builder.Property(e => e.Level).IsRequired();
        }
    }
}
