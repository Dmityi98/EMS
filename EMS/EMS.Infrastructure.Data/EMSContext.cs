using System.Configuration;
using EMS.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EMS.Infrastructure.Data
{
    public class EMSContext : DbContext
    {   
        public DbSet<Notes> Notes {  get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folderPath = Path.Combine(Environment.CurrentDirectory, "Data");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var databasePath = Path.Combine(folderPath, "mydatabase.db");
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }
        public EMSContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>().ToTable("Notes");
            modelBuilder.Entity<Employee>().ToTable("Employees");
        }
    }
}
