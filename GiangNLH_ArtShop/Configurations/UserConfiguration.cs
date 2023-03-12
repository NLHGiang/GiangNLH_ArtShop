using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.FullName).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(c => c.Address).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(c => c.Username).HasMaxLength(20).IsUnicode(false).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(20).IsUnicode(false).IsRequired();

            builder.Property(c => c.CreatedTime).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Role>(c => c.Role)
            .WithMany(c => c.Users)
            .HasForeignKey(c => c.IdRole)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }

}