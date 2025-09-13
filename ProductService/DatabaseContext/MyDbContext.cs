using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.DatabaseContext
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Productscs> Products { get; set; }
    }
}
