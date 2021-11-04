using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAPISourceCode.Models;
using test.Models;

namespace ShopAPISourceCode.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(s => s.AddressId);

            builder.Property(s => s.AddressPostalCode).HasColumnType("DECIMAL").HasMaxLength(10).IsFixedLength(true);

            builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.AddressUserId)
            .IsRequired(true);
        }
    }
}
