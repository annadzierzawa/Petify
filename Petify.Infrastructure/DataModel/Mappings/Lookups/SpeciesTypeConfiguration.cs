using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Common.Lookups;
using Petify.Domain.Lookups;
using static Petify.Common.Lookups.SpeciesTypeLookup;

namespace Petify.Infrastructure.DataModel.Mappings.Lookups
{
    public class SpeciesTypeConfiguration : IEntityTypeConfiguration<SpeciesType>
    {
        public void Configure(EntityTypeBuilder<SpeciesType> builder)
        {
            builder.ToTable("SpeciesType", "Lookup");
            builder.HasKey(e => e.Id);

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<SpeciesType> builder)
        {
            foreach (var ds in Enum.GetValues(typeof(SpeciesTypeEnum)))
            {
                builder.HasData(new SpeciesType { Id = (int)ds, Name = SpeciesTypeLookup.Descriptions[(int)ds] });
            }
        }
    }
}
