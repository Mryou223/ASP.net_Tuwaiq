using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    internal class ClinicContext : DbContext {

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Speciality> Specialities { get; set; } = null!;

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=LAPTOP-S41BDCKA\\SQLEXPRESS;Database=Clinic;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>()
                .Property(d => d.Salary)
                .HasDefaultValue(10000.0);

            modelBuilder.Entity<Speciality>()
                .HasData(
                    new Speciality { Id = 1, Name = "Cardiology" },
                    new Speciality { Id = 2, Name = "Neurology" },
                    new Speciality { Id = 3, Name = "Pediatrics" }
                );


            //modelBuilder.Entity<Doctor>()
            //    .HasOne(d => d.Speciality)
            //    .WithMany(s => s.Doctors)
            //    .HasForeignKey(d => d.SpecialityId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
