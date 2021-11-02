using Microsoft.EntityFrameworkCore;
using ShopAPISourceCode.Data.Configurations;
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
        public DbSet<TagProduct> TagProducts { set; get; }
        public DbSet<Transaction> Transactions { set; get; }
        public DbSet<Categorie> Categories { set; get; }
        public DbSet<CategorieProduct> CategorieProducts { get; set; }
        public DbSet<Like> Likes { set; get; }
        public DbSet<Notice> Notices { set; get; }
        public DbSet<Spec> Specs { get; set; }


        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AddressConfiguration());

            modelBuilder.ApplyConfiguration(new CartConfiguration());

            modelBuilder.ApplyConfiguration(new CartItemConfiguration());

            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

            modelBuilder.ApplyConfiguration(new OptionConfiguration());

            modelBuilder.ApplyConfiguration(new ImageConfiguration());

            modelBuilder.ApplyConfiguration(new SpecConfiguration());

            modelBuilder.ApplyConfiguration(new MetaConfiguration());

            modelBuilder.ApplyConfiguration(new TagConfiguration());

            modelBuilder.ApplyConfiguration(new TagProductConfiguration());

            modelBuilder.ApplyConfiguration(new ReviewConfiguration());

            modelBuilder.ApplyConfiguration(new LikeConfiguration());

            modelBuilder.ApplyConfiguration(new NoticeConfiguration());

            modelBuilder.ApplyConfiguration(new CategorieConfiguration());

            modelBuilder.ApplyConfiguration(new CategorieProductConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new TransactionConfiguration());


            
        }







    }
}
