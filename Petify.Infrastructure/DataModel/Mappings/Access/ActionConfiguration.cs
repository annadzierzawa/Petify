using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petify.Common.Auth.Access.Lookups;
using System;
using Action = Petify.Domain.Access.Action;


namespace Petify.Infrastructure.DataModel.Mappings.Access
{
    public class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("Action", "Access");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Action> builder)
        {
            foreach (var action in Enum.GetValues(typeof(Actions)))
            {
                builder.HasData(new Action((int)action, ActionLookup.Descriptions[(int)action]));
            }
        }
    }
}
