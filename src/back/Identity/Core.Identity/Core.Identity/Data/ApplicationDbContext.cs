using Core.Identity.Models.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataProtectionKeyContext
    {
        protected readonly IHttpContextAccessor _contextAccessor;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext(IHttpContextAccessor contextAccessor, DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _contextAccessor = contextAccessor;
        }



        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        DbSet<DataProtectionKey> IDataProtectionKeyContext.DataProtectionKeys { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var m in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var sp in m.GetProperties().Where(p => p.IsShadowProperty()))
                {
                    var fk = sp.GetContainingForeignKeys().Where(f => f.Properties.Count == 1).FirstOrDefault();
                    if (fk != null && fk.PrincipalKey.Properties.Count == 1 && fk.DependentToPrincipal != null)
                        sp.SetColumnName($"{fk.DependentToPrincipal.Name}_{fk.PrincipalKey.Properties.Single().GetColumnName()}");
                }
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserClaim<string>>()
                        .Property(x => x.UserId)
                        .HasColumnName(nameof(IdentityUserClaim<string>.UserId));

            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Claims).WithOne().HasForeignKey(x => x.UserId);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyPolicies();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken token = default)
        {
            ApplyPolicies();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, token);
        }

        protected void ApplyPolicies()
        {
            //            var userId = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
