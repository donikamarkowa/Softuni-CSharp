using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
            
        }
        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Homework> Homeworks { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<StudentCourse> StudentCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StudentCourse>()
                .HasKey(c => new { c.StudentId, c.CourseId});

            modelBuilder.Entity<Homework>()
                .HasOne(c => c.Course)
                .WithMany(h => h.Homeworks)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Homework>()
                .HasOne(s => s.Student)
                .WithMany(h => h.Homeworks)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}