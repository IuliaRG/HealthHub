
using HospitalCommon.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HospitalDAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Salon> Salons { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
            .HasOne<Salon>(s => s.Salon)
            .WithOne(ad => ad.Patient)
            .HasForeignKey<Salon>(ad => ad.PatientId);
        }
    }
}
