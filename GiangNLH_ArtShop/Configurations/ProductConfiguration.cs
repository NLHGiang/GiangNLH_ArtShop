﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GiangNLH_ArtShop.Models;

namespace GiangNLH.ArtShop.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.Name).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(c => c.Amount).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.ReducedPrice).IsRequired();
            builder.Property(c => c.Image).IsUnicode(false).IsRequired();

            builder.Property(c => c.CreatedTime).IsRequired();
            builder.Property(c => c.Status).IsRequired();
        }
    }

}