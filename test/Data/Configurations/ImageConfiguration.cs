using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPISourceCode.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(s => s.ImageId);

            builder.Ignore(s => s.ImageImage);

            builder.HasOne<Option>().WithMany()
            .HasForeignKey(s => s.ImageOptionId);
        }
    }
}
