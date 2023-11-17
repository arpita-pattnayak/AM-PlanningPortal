using AM.PP.DataContracts.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
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
