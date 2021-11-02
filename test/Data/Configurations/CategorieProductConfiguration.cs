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
    public class CategorieProductConfiguration : IEntityTypeConfiguration<CategorieProduct>
    {
        public void Configure(EntityTypeBuilder<CategorieProduct> builder)
        {
            builder.HasKey(s => s.CategorieProductId);

            builder.HasOne<Categorie>().WithMany().HasForeignKey(s => s.CategorieProductCategorieId).IsRequired(false);

            builder.HasOne<Product>().WithMany() .HasForeignKey(s => s.CategorieProductProductId).IsRequired(false);
        }
    }
}
