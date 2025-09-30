using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data

{
    public class BarlangDbContext : DbContext

    {
        public BarlangDbContext(DbContextOptions<BarlangDbContext> options) : base(options)
        {

        }

        public DbSet<WebApplication2.Models.barlang> Barlangok { get; set; }
    }
}
