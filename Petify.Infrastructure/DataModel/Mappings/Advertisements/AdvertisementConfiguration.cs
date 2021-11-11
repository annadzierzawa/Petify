using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Domain.Advertisements;
using Petify.Domain.Lookups;

namespace Petify.Infrastructure.DataModel.Mappings.Advertisements
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.ToTable("Advertisement", "Advertisement");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.PetId).IsRequired();
            builder.Property(e => e.OwnerId).IsRequired();
            builder.HasOne(e => e.Pet).WithMany().HasForeignKey(e => e.PetId);
            builder.HasOne<AdvertisementType>().WithMany().HasForeignKey(e => e.AdvertisementTypeId);
            builder.HasMany(e => e.CyclicalAssistanceDays).WithOne().HasForeignKey(c => c.AdvertisementId);
            builder.OwnsOne(
                e => e.Dates,
                d =>
                {
                    d.Property(dd => dd.StartDate).IsRequired(false);
                    d.Property(dd => dd.EndDate).IsRequired(false);
                });
        }
    }
}
