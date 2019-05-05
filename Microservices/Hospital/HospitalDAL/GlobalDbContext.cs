using HospitalCommon.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HospitalDAL
{
    public class GlobalDbContext : DbContext
    {
        public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<UserInTenant> UserInTenants { get; set; }

        public class GlobalDbContextFactory : IDesignTimeDbContextFactory<GlobalDbContext>
        {
            public GlobalDbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<GlobalDbContext>();
                builder.UseSqlServer(@"Server=DESKTOP-CA1SMFG\SQLEXPRESS;Database=Global;Trusted_Connection=True;Integrated Security=False;MultipleActiveResultSets=True;user id=sa;password=parola12",
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(GlobalDbContext).GetTypeInfo().Assembly.GetName().Name));

                return new GlobalDbContext(builder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInTenant>()
                .HasKey(x => new { x.UserId, x.TenantId });

        }
    }
}
