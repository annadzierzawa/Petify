using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Domain.Advertisements;

namespace Petify.Infrastructure.DataModel.Mappings.Advertisements
{
    public class PetAdvertisementConfiguration : IEntityTypeConfiguration<PetAdvertisement>
    {
        public void Configure(EntityTypeBuilder<PetAdvertisement> builder)
        {
            builder.ToTable("PetAdvertisement", "Advertisement");
            builder.HasKey(e => new { e.AdvertisementId, e.PetId });
            builder.HasOne(e => e.Pet)
                .WithMany()
                .HasForeignKey(e => e.PetId);
            builder.HasOne(e => e.Advertisement)
                .WithMany()
                .HasForeignKey(e => e.AdvertisementId);
        }
    }
}
