using GiangNLH.ArtShop.Configurations;
using GiangNLH_ArtShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GiangNLH_ArtShop.ArtShopDbContext
{
    public partial class ArtShopContext : DbContext
    {
        public ArtShopContext()
        {
        }

        public ArtShopContext(DbContextOptions<ArtShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBill> ProductBills { get; set; }
        public virtual DbSet<ProductCart> ProductCarts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI\\SQLExpress;Database=GiangNLH_ArtShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());

            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CartDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductBillConfiguration());
        }
    }
}
