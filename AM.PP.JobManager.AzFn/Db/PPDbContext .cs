using AM.PP.DataContracts.Model;
using Microsoft.EntityFrameworkCore;

namespace AM.PP.JobManager.AzFn.Db
{
    public class PPDbContext : DbContext
    {
        public PPDbContext(DbContextOptions<PPDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> user { get; set; }
        // Define other DbSet properties for your tables
    }
}
