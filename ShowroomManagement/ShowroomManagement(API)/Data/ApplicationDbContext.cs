using Microsoft.EntityFrameworkCore;

namespace ShowroomManagement_API_.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
    }
}