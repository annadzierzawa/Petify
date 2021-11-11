using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Petify.Common.Auth;
using Petify.Domain.Access;
using Petify.Domain.Advertisements;
using Petify.Domain.Common;
using Petify.Domain.Pets;
using Petify.Infrastructure.DataModel.Mappings.Access;
using Petify.Infrastructure.DataModel.Mappings.Advertisements;
using Petify.Infrastructure.DataModel.Mappings.Lookups;
using Petify.Infrastructure.DataModel.Mappings.Pets;
using SRW_CRM.Infrastructure.DataModel.Mappings.Access;
using Action = Petify.Domain.Access.Action;

namespace Petify.Infrastructure.DataModel.Context
{
    public class PetifyContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public PetifyContext() { }

        public PetifyContext(DbContextOptions<PetifyContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Action> AccessActions { get; set; }
        public DbSet<RoleAction> AccessRoleActions { get; set; }
        public DbSet<Role> AccessRoles { get; set; }
        public DbSet<User> AccessUsers { get; set; }
        public DbSet<UserAction> AccessUserActions { get; set; }
        public DbSet<UserPermission> AccessUserPermissions { get; set; }
        public DbSet<UserRole> AccessUserRoles { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ActionConfiguration());
            builder.ApplyConfiguration(new RoleActionConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserActionConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserPermissionConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

            builder.ApplyConfiguration(new SpeciesTypeConfiguration());
            builder.ApplyConfiguration(new PetConfiguration());

            builder.ApplyConfiguration(new AdvertisementTypeConfiguration());
            builder.ApplyConfiguration(new CyclicalAssistanceDayConfiguration());
            builder.ApplyConfiguration(new AdvertisementConfiguration());
            builder.ApplyConfiguration(new PetAdvertisementConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Petify"));
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.UserId;
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
