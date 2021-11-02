using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopAPISourceCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPISourceCode.Data.Configurations
{
    public class CategorieConfiguration : IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder)
        {
            builder.HasKey(s => s.CategorieId);
            
            builder.Ignore(s => s.CategorieImage);
            
            builder.HasOne<Categorie>().WithMany().HasForeignKey(s => s.CategorieParentId).IsRequired(false);
        }
    }
}
