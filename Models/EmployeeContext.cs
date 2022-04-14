using Microsoft.EntityFrameworkCore;

namespace REST_API_CRUD.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
