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
                .HasMany(x => x.UserLikes)
                .WithOne(y => y.LikeUser)
                .IsRequired() ;
            modelBuilder.Entity<User>()
               .HasMany(x => x.UserNotices)
               .WithOne(y => y.NoticeUser)
               .IsRequired();
               
            modelBuilder.Entity<Product>()
               .HasMany(x => x.ProductLikes)
               .WithOne(x => x.LikeProduct)
               .IsRequired();
            modelBuilder.Entity<Product>()
               .HasMany(x => x.ProductNotices)
               .WithOne(x => x.NoticeProduct)
               .IsRequired();

            modelBuilder.Entity<Like>()
                .HasOne(x => x.LikeUser)
                .WithMany(y => y.UserLikes)
                .IsRequired()
                .HasForeignKey("LikeUserId");
            modelBuilder.Entity<Like>()
                .HasOne(x => x.LikeProduct)
                .WithMany(y => y.ProductLikes)
                .IsRequired()
                .HasForeignKey("LikeProductId");

            modelBuilder.Entity<Notice>()
                .HasOne(x => x.NoticeProduct)
                .WithMany(y => y.ProductNotices)
                .IsRequired()
                .HasForeignKey("NoticeProductId");
            modelBuilder.Entity<Notice>()
                .HasOne(x => x.NoticeUser)
                .WithMany(y => y.UserNotices)
                .IsRequired()
                .HasForeignKey("NoticeUserId");

            modelBuilder.Entity<Product>()
               .HasMany(x => x.ProductCategories)
               .WithOne(x => x.ProductCategorieProduct)
               .IsRequired();

            modelBuilder.Entity<Categorie>()
               .HasMany(x => x.CategorieProducts)
               .WithOne(x => x.ProductCategorieCategorie)
               .IsRequired();
            modelBuilder.Entity<Categorie>()
               .HasMany(x => x.CategorieChilds)
               .WithOne(x => x.CategorieParent)
               .HasForeignKey("CategorieParentId");

            modelBuilder.Entity<ProductCategorie>()
                .HasOne(x => x.ProductCategorieCategorie)
                .WithMany(y => y.CategorieProducts)
                .IsRequired()
                .HasForeignKey("ProductCategorieCategorieId");
            modelBuilder.Entity<ProductCategorie>()
                .HasOne(x => x.ProductCategorieProduct)
                .WithMany(y => y.ProductCategories)
                .IsRequired()
                .HasForeignKey("ProductCategorieProductId");

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
        }

        public DbSet<ShopAPISourceCode.Models.Spec> Spec { get; set; }



    }
}
