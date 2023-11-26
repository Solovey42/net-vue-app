using Microsoft.EntityFrameworkCore;

namespace API.Domain.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WebSiteDB;TrustServerCertificate=True;Trusted_Connection=True;");
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}