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
    public class NoticeConfiguration : IEntityTypeConfiguration<Notice>
    {
        public void Configure(EntityTypeBuilder<Notice> builder)
        {
            builder.HasKey(s => s.NoticeId);

            builder.HasOne<User>().WithMany().HasForeignKey(s => s.NoticeUserId);

            builder.HasOne<Product>().WithMany().HasForeignKey(s => s.NoticeProductId);
        }
    }
}
