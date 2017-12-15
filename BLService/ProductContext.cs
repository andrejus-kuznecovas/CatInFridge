using System.Data.Entity;
using System.Linq;

namespace BLService
{
    public class ProductContext : DbContext
    {
        static ProductContext()
        {
            Database.SetInitializer<ProductContext>(null);
        }
        public ProductContext() : base (@"ProductContext"){ }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        
        /*
        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).Select(e => e.Entity)){
                history.
            }
        }
        */
    }
}
