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
        public DbSet<CategorieProduct> CategorieProducts { get; set; }
        public DbSet<Like> Likes { set; get; }
        public DbSet<Notice> Notices { set; get; }
        public DbSet<Spec> Specs { get; set; }


        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(s => s.AddressId);
            modelBuilder.Entity<Address>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.AddressUserId);
            

            modelBuilder.Entity<Cart>()
                .HasKey(s => s.CartId);
            modelBuilder.Entity<Cart>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.CartUserId);

            modelBuilder.Entity<Option>()
                .HasKey(s => s.OptionId);
            modelBuilder.Entity<Option>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.OptionProductId);



            modelBuilder.Entity<Image>().HasKey(s => s.ImageId);
            modelBuilder.Entity<Image>().Ignore(s => s.ImageImage);
            modelBuilder.Entity<Image>()
            .HasOne<Option>()
            .WithMany()
            .HasForeignKey(s => s.ImageProductOptionId);
            


            modelBuilder.Entity<Spec>()
                .HasKey(s => s.SpecId);
            modelBuilder.Entity<Spec>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.SpecProductId);
            

            modelBuilder.Entity<Meta>()
                .HasKey(s => s.MetaId);
            modelBuilder.Entity<Meta>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.MetaProductId);
            


            modelBuilder.Entity<TagProduct>()
                .HasKey(s => s.TagProductId);
            modelBuilder.Entity<TagProduct>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.TagProductProductId);
            modelBuilder.Entity<TagProduct>()
            .HasOne<Tag>()
            .WithMany()
            .HasForeignKey(s => s.TagProductTagId);


            modelBuilder.Entity<Review>()
                .HasKey(s => s.ReviewId);
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
                .HasKey(s => s.LikeId);
            modelBuilder.Entity<Like>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.LikeProductId);
            modelBuilder.Entity<Like>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.LikeUserId);


            modelBuilder.Entity<Notice>()
                .HasKey(s => s.NoticeId);
            modelBuilder.Entity<Notice>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.NoticeUserId);
            modelBuilder.Entity<Notice>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.NoticeProductId);


            modelBuilder.Entity<Categorie>().HasKey(s => s.CategorieId);
            modelBuilder.Entity<Categorie>().Ignore(s => s.CategorieImage);
            modelBuilder.Entity<Categorie>()
            .HasOne<Categorie>()
            .WithMany()
            .HasForeignKey(s => s.CategorieParentId)
            .IsRequired(false);


            modelBuilder.Entity<CategorieProduct>()
                .HasKey(s => s.CategorieProductId);
            modelBuilder.Entity<CategorieProduct>()
            .HasOne<Categorie>()
            .WithMany()
            .HasForeignKey(s => s.CategorieProductCategorieId)
            .IsRequired(false);
            modelBuilder.Entity<CategorieProduct>()
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(s => s.CategorieProductProductId)
            .IsRequired(false);


            modelBuilder.Entity<User>().Ignore(s => s.UserImage);
        }







    }
}
