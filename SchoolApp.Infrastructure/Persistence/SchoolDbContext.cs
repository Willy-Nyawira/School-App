using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.Entities;

namespace SchoolApp.Infrastructure.Persistence
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) 
            :base(options)
        { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
       .HasKey(e => e.Id);

            modelBuilder.Entity<Student>()
       .OwnsOne(s => s.Email);
            modelBuilder.Entity<Student>()
                .OwnsOne(s => s.PhoneNumber);

            modelBuilder.Entity<Teacher>().OwnsOne(t => t.Email);
            modelBuilder.Entity<Teacher>().OwnsOne(t => t.PhoneNumber);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId); 

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.AssignedTeacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
