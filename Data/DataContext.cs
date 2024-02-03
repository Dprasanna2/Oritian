using Microsoft.EntityFrameworkCore;
using OritainAPI.ViewModels;

namespace OritainAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //public DbSet<EmployeeDetails> Employees { get; set; }
        //public DbSet<EmployeeTask> EmployeeTasks { get; set; }

        public DbSet<EmployeeData> employeeData { get; set; }

    }
}
