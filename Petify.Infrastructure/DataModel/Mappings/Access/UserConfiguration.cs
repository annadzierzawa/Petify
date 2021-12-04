using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Domain.Access;

namespace Petify.Infrastructure.DataModel.Mappings.Access
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "Access");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasMany(e => e.Pets).WithOne().HasForeignKey(p => p.OwnerId);
            builder.HasMany(e => e.Advertisements).WithOne(e => e.Owner).HasForeignKey(p => p.OwnerId).IsRequired();
        }
    }
}
