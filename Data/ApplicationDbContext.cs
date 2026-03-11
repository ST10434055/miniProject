using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammeManagementSystem.Models;

namespace ProgrammeManagementSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<ModuleAssignment> ModuleAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ModuleAssignment>()
                .HasOne(ma => ma.Lecturer)
                .WithMany()
                .HasForeignKey(ma => ma.LecturerID);

            modelBuilder.Entity<ModuleAssignment>()
                .HasOne(ma => ma.Module)
                .WithMany()
                .HasForeignKey(ma => ma.ModuleID);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Student)
                .WithMany()
                .HasForeignKey(r => r.StudentID);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Module)
                .WithMany()
                .HasForeignKey(r => r.ModuleID);
        }
    }
}
