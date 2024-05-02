using Microsoft.EntityFrameworkCore;
using TestProject.Model;

namespace TestProject.DbConnection
{
    public class ApplicationDbContext : DbContext
    {
         //Tables
        public DbSet<Cars> Cars { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
