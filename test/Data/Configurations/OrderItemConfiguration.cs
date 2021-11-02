using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPISourceCode.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(s => s.OrderItemId);
            
            builder.HasOne<Order>().WithMany().HasForeignKey(s => s.OrderItemOrderId);
            
            builder.HasOne<Option>().WithMany().HasForeignKey(s => s.OrderItemOptionId);
        }
    }
}
