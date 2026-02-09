using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Models;
namespace Infrastructure.postgres
{
    public class EntityContext : DbContext
    {
        // Constructor này bắt buộc phải có để nhận cấu hình từ Factory hoặc Program.cs
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public DbSet<AccountModel> AccountModels { get; set; }
        public DbSet<AccountRoleModel> AccountRoleModels { get; set; }
        public DbSet<PermissionModel> PermissionModels { get; set; }
        public DbSet<RoleModel> RoleModels { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}