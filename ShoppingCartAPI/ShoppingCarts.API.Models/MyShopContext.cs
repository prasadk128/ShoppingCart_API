using Microsoft.EntityFrameworkCore;

namespace ShoppingCartAPI.Models
{
    public partial class MyShopContext : DbContext
    {
        public MyShopContext()
        {
        }

        public MyShopContext(DbContextOptions<MyShopContext> options)
            : base(options)
        {
        }

  
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                _ = _ = optionsBuilder.UseSqlServer("Server=DESKTOP-HFLVBE6\\MSSQLSERVER1;Initial Catalog=ShoppingCart;User ID=sa;Password=Config900$");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cart>()
           .HasKey(o => new { o.CartId, o.UserId,o.ProductId });
         
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

