using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAPISourceCode.Models;
using test.Models;

namespace ShopAPISourceCode.Data.Configurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(s => s.OptionId);

            builder.HasOne<Product>().WithMany().HasForeignKey(s => s.OptionProductId);
        }
    }
}
