using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Petify.IdentityServer.Infrastructure.Data;

namespace Petify.IdentityServer
{
    public class PetifyContext : DbContext
    {
        public PetifyContext() { }

        public PetifyContext(DbContextOptions<PetifyContext> options) : base(options) { }

        public IQueryable<User> Users => Set<User>().AsNoTracking();
        public IQueryable<UserPermission> UserPermission => Set<UserPermission>().AsNoTracking();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "Access").HasKey(c => c.Id);
            modelBuilder.Entity<UserPermission>().ToView("VW_UserPermissions", "Access").HasKey(c => new { c.UserId, c.ActionId });
        }

        public override int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new InvalidOperationException("This context is read-only.");
        }
    }
}
