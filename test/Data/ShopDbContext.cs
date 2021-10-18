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
        public DbSet<Address> Addresses { set; get; }
        public DbSet<Cart> Carts { set; get; }
        public DbSet<CartItem> CartItems { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderItem> OrderItems { set; get; }
        public DbSet<Meta> Meta { set; get; }
        public DbSet<Option> Options { set; get; }
        public DbSet<Image> Images { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<Transaction> Transactions { set; get; }
        public DbSet<Categorie> Categories { set; get; }
        public DbSet<Like> Likes { set; get; }
        public DbSet<Notice> Notices { set; get; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.UserProductsLiked)
                .WithOne(y => y.LikeUser)
                .IsRequired();

            modelBuilder.Entity<Product>()
               .HasMany(x => x.ProductUsersLiked)
               .WithOne(x => x.LikeProduct)
               .IsRequired();

            modelBuilder.Entity<Like>()
                .HasOne(x => x.LikeUser)
                .WithMany(y => y.UserProductsLiked)
                .IsRequired()
                .HasForeignKey("LikeUserId");
            modelBuilder.Entity<Like>()
                .HasOne(x => x.LikeProduct)
                .WithMany(y => y.ProductUsersLiked)
                .IsRequired()
                .HasForeignKey("LikeProductId");

        }



    }
}
