using System;
using CollegeAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI.Data.DBConnection
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Student> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<Classes> classes { get; set; }
        public DbSet<Subject> subject { get; set; }
            
        
    }
}