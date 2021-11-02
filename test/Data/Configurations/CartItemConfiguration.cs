using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPISourceCode.Data.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(s => s.CartItemId);
            
            builder.HasOne<Cart>().WithMany().HasForeignKey(s => s.CartItemCartId);
            
            builder.HasOne<Option>().WithMany().HasForeignKey(s => s.CartItemOptionId);
        }
    }
}
