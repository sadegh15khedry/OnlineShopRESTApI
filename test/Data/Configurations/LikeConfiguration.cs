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
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(s => s.LikeId);

            builder.HasOne<Product>().WithMany().HasForeignKey(s => s.LikeProductId);

            builder.HasOne<User>().WithMany().HasForeignKey(s => s.LikeUserId);
        }
    }
}
