using CollegeProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEFbyMigration.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Designation>Designations{ get; set; }
      

    }
}
