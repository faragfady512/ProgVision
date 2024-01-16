using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgVision.DAL.Entities;

namespace ProgVision.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public DbSet<Revision> Revisions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Enroll> Enrollments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
