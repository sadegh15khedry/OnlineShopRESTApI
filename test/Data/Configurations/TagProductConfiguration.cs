using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAPISourceCode.Models;
using test.Models;

namespace ShopAPISourceCode.Data.Configurations
{
    public class TagProductConfiguration : IEntityTypeConfiguration<TagProduct>
    {
        public void Configure(EntityTypeBuilder<TagProduct> builder)
        {
            builder.HasKey(s => s.TagProductId);

            builder.HasOne<Product>().WithMany().HasForeignKey(s => s.TagProductProductId);

            builder.HasOne<Tag>().WithMany().HasForeignKey(s => s.TagProductTagId);

        }
    }
}
