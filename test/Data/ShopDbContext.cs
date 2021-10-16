using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Models;
using test.Models;

namespace test.Data
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Review> Reviews { set; get; }
        public DbSet<UserAddress> Addresses { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<CartItem> CartItems { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderItem> OrderItems { set; get; }
        public DbSet<ProductMeta> ProductMeta { set; get; }
        public DbSet<ProductOption> ProductOptions { set; get; }
        public DbSet<ProductImage> ProductImages { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<ProductTag> Tags { set; get; }
        public DbSet<Transaction> Transactions { set; get; }
        public DbSet<Categorie> Categories { set; get; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }
    }
}
