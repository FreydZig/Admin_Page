using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<CompanyCustomer> Company_customers { get; set; }
        public DbSet<CompanyExecutor> Company_executors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkerProject> Workers_projects { get; set; }      

    }
}
