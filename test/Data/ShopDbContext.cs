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
        public DbSet<TagProduct> TagProducts { set; get; }
        public DbSet<Transaction> Transactions { set; get; }
        public DbSet<Categorie> Categories { set; get; }
        public DbSet<Like> Likes { set; get; }
        public DbSet<Notice> Notices { set; get; }
        public DbSet<Spec> Specs { get; set; }
        

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Address>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.AddressUserId);

            modelBuilder.Entity<Option>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.OptionProductId);

            modelBuilder.Entity<Image>()
            .HasOne<Option>()
            .WithMany()
            .HasForeignKey(s => s.ImageProductOptionId);

            modelBuilder.Entity<Spec>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.SpecProductId);

            modelBuilder.Entity<Meta>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.MetaProductId);

            modelBuilder.Entity<TagProduct>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.TagProductProductId);

            modelBuilder.Entity<TagProduct>()
            .HasOne<Tag>()
            .WithMany()
            .HasForeignKey(s => s.TagProductTagId);

            modelBuilder.Entity<Review>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.ReviewUserId);

            modelBuilder.Entity<Review>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.ReviewProductId);

            modelBuilder.Entity<Review>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.ReviewProductId);

            modelBuilder.Entity<Like>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.LikeProductId);
            modelBuilder.Entity<Like>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.LikeUserId);

            modelBuilder.Entity<Notice>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.NoticeUserId);
            modelBuilder.Entity<Notice>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.NoticeProductId);

        }

        

        



    }
}
