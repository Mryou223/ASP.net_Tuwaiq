using ClinicDM.Helpers;
using ClinicDM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    public class ClinicContext : IdentityDbContext<IdentityUser> {

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;

        public ClinicContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Patient>()
                .HasData(
                new Patient { Id = 1, FullName = "Ahmed Ali", NationalId = "123456789012", DateOfBirth = new DateTime(2000, 1, 1), Email = "ahmed@example.com", Gender = "Male", PhoneNumber = "0501234567" }
                );

            modelBuilder.Entity<Doctor>()
                .HasData(new Doctor { Id = 1, Name = "Omar" }
                );

            modelBuilder.Entity<Appointment>()
                .HasData(
                new Appointment { Id = 1, appointmentDate = new DateTime(2025, 8, 1, 17, 0, 0), DoctorId = 1, patientId = 1, Status = "Scheduled" },
                new Appointment { Id = 2, appointmentDate = new DateTime(2025, 7, 1, 17, 0, 0), DoctorId = 1, patientId = 1, Status = "Completed" },
                new Appointment { Id = 3, appointmentDate = new DateTime(2025, 7, 5, 17, 0, 0), DoctorId = 1, patientId = 1, Status = "Scheduled" }
                );


            modelBuilder.Entity<IdentityUser>(b => b.ToTable("Users"));
            modelBuilder.Entity<IdentityRole>(b => b.ToTable("Roles"));
            modelBuilder.Entity<IdentityRoleClaim<string>>(b => b.ToTable("RoleClaims"));
            modelBuilder.Entity<IdentityUserClaim<string>>(b => b.ToTable("UserClaims"));
            modelBuilder.Entity<IdentityUserRole<string>>(b => b.ToTable("UserRoles"));
            modelBuilder.Entity<IdentityUserToken<string>>(b => b.ToTable("UserTokens"));
            modelBuilder.Entity<IdentityUserLogin<string>>(b => b.ToTable("UserLogins"));


            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Id = "06b5c522-3807-4f76-bf9e-58a473b8f1c9", ConcurrencyStamp = "06b5c522-3807-4f76-bf9e-58a473b8f1c9", Name = AppRoles.Admin.ToString(), NormalizedName = AppRoles.Admin.ToString().ToUpper() },
                    new IdentityRole { Id = "f1d12335-1e1a-46ff-9a78-06863beae944", ConcurrencyStamp = "f1d12335-1e1a-46ff-9a78-06863beae944", Name = AppRoles.Receptionist.ToString(), NormalizedName = AppRoles.Receptionist.ToString().ToUpper() },
                    new IdentityRole { Id = "c552c65b-d753-401d-ade0-5f1a409ef279", ConcurrencyStamp = "c552c65b-d753-401d-ade0-5f1a409ef279", Name = AppRoles.Doctor.ToString(), NormalizedName = AppRoles.Doctor.ToString().ToUpper() }
                );
        }
    }
}
