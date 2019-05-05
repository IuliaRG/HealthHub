using PharmacyCommon.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PharmacyDAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UserDB;Trusted_Connection=True;");


        //    }
        //}

        public DbSet<User> User { get; set; }

        public DbSet<Pharmacy> Pharmacy { get; set; }

    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(@"Server=DESKTOP-CA1SMFG\SQLEXPRESS;Database=HealthHub;Trusted_Connection=True;Integrated Security=False;MultipleActiveResultSets=True;user id=sa;password=parola12",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new ApplicationDbContext(builder.Options);
        }
    }
}
