using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Configurations
{
    public class ProductCartConfiguration : IEntityTypeConfiguration<ProductCart>
    {
        public void Configure(EntityTypeBuilder<ProductCart> builder)
        {
            builder.ToTable("ProductCart");
            builder.HasKey(c => new { c.IdProduct, c.IdCart });

            builder.Property(c => c.Amount).IsRequired();

            builder.Property(c => c.CreatedTime).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Product>(c => c.Product)
            .WithMany(c => c.ProductCarts)
            .HasForeignKey(c => c.IdProduct)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Cart>(c => c.Cart)
            .WithMany(c => c.ProductCarts)
            .HasForeignKey(c => c.IdCart)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }

}