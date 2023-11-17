using AM.PP.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace AM.PP.Repository
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {
        }

        public DbSet<UsersModel> Users { get; set; }
    }
}