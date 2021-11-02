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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
           builder.HasKey(s => s.AddressId);
            
            builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(s => s.AddressUserId)
            .IsRequired(true);
        }
    }
}
