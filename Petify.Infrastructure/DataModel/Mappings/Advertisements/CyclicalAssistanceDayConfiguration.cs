using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Domain.Advertisements;

namespace Petify.Infrastructure.DataModel.Mappings.Advertisements
{
    public class CyclicalAssistanceDayConfiguration : IEntityTypeConfiguration<CyclicalAssistanceDay>
    {
        public void Configure(EntityTypeBuilder<CyclicalAssistanceDay> builder)
        {
            builder.ToTable("CyclicalAssistanceDay", "Advertisement");
            builder.HasKey(e => e.Id);
        }
    }
}
