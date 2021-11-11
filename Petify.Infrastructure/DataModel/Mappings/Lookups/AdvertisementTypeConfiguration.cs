using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Common.Lookups;
using Petify.Domain.Lookups;
using static Petify.Common.Lookups.AdvertisementTypeLookup;

namespace Petify.Infrastructure.DataModel.Mappings.Lookups
{
    public class AdvertisementTypeConfiguration : IEntityTypeConfiguration<AdvertisementType>
    {
        public void Configure(EntityTypeBuilder<AdvertisementType> builder)
        {
            builder.ToTable("AdvertisementType", "Lookup");
            builder.HasKey(e => e.Id);

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<AdvertisementType> builder)
        {
            foreach (var ds in Enum.GetValues(typeof(AdvertisementTypeEnum)))
            {
                builder.HasData(new SpeciesType { Id = (int)ds, Name = AdvertisementTypeLookup.Descriptions[(int)ds] });
            }
        }
    }
}
