using Microsoft.EntityFrameworkCore;

namespace Persistances.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAdt> ProductAdts { get; set; }
        public DbSet<ProductAdtPrice> ProductAdtPrices { get; set; }
        public DbSet<ProductAdtType> ProductAdtTypes { get; set; }
        public DbSet<ProductDeliver> ProductDelivers { get; set; }
        public DbSet<ProductDeliverSize> ProductDeliverSizes { get; set; }
        public DbSet<ProductJeld> ProductJelds { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductMaterialAttribute> ProductMaterialAttributes { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductPrintKind> ProductPrintKinds { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductsGroup> ProductsGroups { get; set; }
        

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			// Configure Product
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(e => e.ProductAdts)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId);

            entity.HasMany(e => e.ProductDelivers)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId);

            entity.HasMany(e => e.ProductMaterials)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId);

            entity.HasMany(e => e.ProductPrintKinds)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId);

            entity.HasMany(e => e.ProductSizes)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId);

        });

        // Configure ProductAdt
        modelBuilder.Entity<ProductAdt>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(e => e.ProductAdtPrices)
                .WithOne(e => e.ProductAdt)
                .HasForeignKey(e => e.ProductAdtId);

            entity.HasMany(e => e.ProductAdtTypes)
                .WithOne(e => e.ProductAdt)
                .HasForeignKey(e => e.ProductAdtId);
        });

        // Configure ProductAdtPrice
        modelBuilder.Entity<ProductAdtPrice>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Configure ProductAdtType
        modelBuilder.Entity<ProductAdtType>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Configure ProductDeliver
        modelBuilder.Entity<ProductDeliver>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(e => e.ProductDeliverSizes)
                .WithOne(e => e.ProductDeliver)
                .HasForeignKey(e => e.ProductDeliverId);
        });

        // Configure ProductDeliverSize
        modelBuilder.Entity<ProductDeliverSize>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Configure ProductJeld
        modelBuilder.Entity<ProductJeld>(entity =>
        {
            entity.HasKey(e => e.ProductId);
        });

        // Configure ProductMaterial
        modelBuilder.Entity<ProductMaterial>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasMany(e => e.ProductMaterialAttributes)
                .WithOne(e => e.ProductMaterial)
                .HasForeignKey(e => e.ProductMaterialId);
        });

        // Configure ProductMaterialAttribute
        modelBuilder.Entity<ProductMaterialAttribute>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Configure ProductPrice
        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Configure ProductPrintKind
        modelBuilder.Entity<ProductPrintKind>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        // Configure ProductSize
        modelBuilder.Entity<ProductSize>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<ProductsGroup>(entity =>
        {
            entity.HasKey(e => e.Id);
        
            entity.HasMany(e => e.Products)
                .WithOne(p => p.ProductsGroup)
                .HasForeignKey(p => p.ProductGroupId);
        });
			
			
			base.OnModelCreating(modelBuilder);

			

        }
	}
}
