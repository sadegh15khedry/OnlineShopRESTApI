using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace ShopAPISourceCode.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(s => s.ReviewId);

            builder.HasOne<User>().WithMany().HasForeignKey(s => s.ReviewUserId);

            builder.HasOne<Product>().WithMany().HasForeignKey(s => s.ReviewProductId);
        }
    }
}
