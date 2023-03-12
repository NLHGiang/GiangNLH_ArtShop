using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");
            builder.HasKey(c => new { c.IdProduct, c.IdCategory });

            builder.Property(c => c.CreatedTime).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Product>(c => c.Product)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(c => c.IdProduct)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Category>(c => c.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(c => c.IdCategory)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }

}