using System;
using System.Linq;
using CollegeAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI.Data.DBConnection
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Users> users { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<Classes> classes { get; set; }
        public DbSet<Subject> subject { get; set; }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}