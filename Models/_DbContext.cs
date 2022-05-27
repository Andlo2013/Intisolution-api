using IntiSolutionApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntiSolutionApi.Models
{
    public class _DbContext:DbContext
    {

        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        {
            //this.Database.SetInitializer; //Database.SetInitializer<_DbContext>(null);
        }

       

        
        public DbSet<customer> Customers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }
        
    }
}
