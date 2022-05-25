using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace labb2Linq.Models
{
    public class PeopleDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set;}


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseName });
            modelbuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseName);
            modelbuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8957B06\SQLEXPRESS;Initial Catalog=SchoolDb;Integrated Security=True;");
        }


    }
}
