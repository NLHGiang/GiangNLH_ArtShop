using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(c => c.CreatedTime).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<User>(c => c.User)
            .WithMany(c => c.Carts)
            .HasForeignKey(c => c.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }

}