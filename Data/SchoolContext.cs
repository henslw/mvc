using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ContosoUniversity.Data
{
    //henslw-mvc1
    //created schoolContext class
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        //henslw-mvc5
        //Added primiary keys
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        //henslw-mvc9
        //added persons keys

        //henslw-mvc1
        //Allows of EF to correctly make tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //henslw-mvc9
            //Had to comment out Student to prevent error because person entity is used instead
            //modelBuilder.Entity<Student>().ToTable("Student");
            
            //henslw-mvc5
            //added entitys
            modelBuilder.Entity<Department>().ToTable("Department");
            //henslw-mvc9
            //Had to comment out Intructor to prevent error because person entity is used instead
            //modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            //henslw-mvc9
            //Added person entity
            modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }
    }
}