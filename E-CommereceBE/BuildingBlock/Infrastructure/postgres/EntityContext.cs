using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Models;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.postgres
{
    public class EntityContext : DbContext
    {

        public DbSet<AccountModel> AccountModels { get; set; }
        public DbSet<AccountRoleModel> AccountRoleModels { get; set; }
        public DbSet<PermissionModel> PermissionModels { get; set; }
        public DbSet<RoleModel> RoleModels { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(6000));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountRoleModel>()
                .HasKey(ar => new {ar.AccountId,ar.RoleId});

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });
        }
    }
}