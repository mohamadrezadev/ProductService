using Microsoft.EntityFrameworkCore;
using Persistances.Data;

namespace Persistance.Test;

public class ProductTests
{
    // In-memory database context setup
    private DbContextOptions<AppDbContext> GetDbOptions()
    {
        return new DbContextOptionsBuilder<AppDbContext> ()
            .UseInMemoryDatabase (databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public void CreateProduct_ShouldAddProductToDatabase()
    {
        // Arrange
        var options = GetDbOptions ();
        using var context = new AppDbContext (options);

        var product = new Product
        {
            WorkTypeId = 1,
            ProductType = 1,
            Circulation = "100",
            CopyCount = "10",
            PageCount = "20",
            PrintSide = 1,
            IsDelete = false,
            MinCirculation = 10,
            MaxCirculation = 1000,
            MinPage = 1,
            MaxPage = 200,
            MinWidth = 5.0f,
            MaxWidth = 20.0f,
            MinLength = 5.0f,
            MaxLength = 30.0f,
            SheetDimensionId = 2,
            FileExtension = ".pdf",
            ProductGroupId = 1
        };

        // Act
        context.Products.Add (product);
        context.SaveChanges ();

        // Assert
        var createdProduct = context.Products.FirstOrDefault (p => p.Id == product.Id);
        Assert.NotNull (createdProduct);
        Assert.Equal ("100", createdProduct.Circulation);
        Assert.False (createdProduct.IsDelete);
    }

    [Fact]
    public void DeleteProduct_ShouldMarkProductAsDeleted()
    {
        // Arrange
        var options = GetDbOptions ();
        using var context = new AppDbContext (options);
        var product = new Product
        {
            WorkTypeId = 1,
            ProductType = 1,
            Circulation = "100",
            CopyCount = "10",
            PageCount = "20",
            PrintSide = 1,
            IsDelete = false,
            MinCirculation = 10,
            MaxCirculation = 1000,
            MinPage = 1,
            MaxPage = 200,
            MinWidth = 5.0f,
            MaxWidth = 20.0f,
            MinLength = 5.0f,
            MaxLength = 30.0f,
            SheetDimensionId = 2,
            FileExtension = ".pdf",
            ProductGroupId = 1
        };
        context.Products.Add (product);
        context.SaveChanges ();

        // Act
        product.IsDelete = true;
        context.SaveChanges ();

        // Assert
        var deletedProduct = context.Products.FirstOrDefault (p => p.Id == 1);
        Assert.NotNull (deletedProduct);
    }

    [Fact]
    public void UpdateProduct_ShouldUpdateProductProperties()
    {
        // Arrange
        var options = GetDbOptions ();
        using var context = new AppDbContext (options);
        var product = new Product
        {
            WorkTypeId = 1,
            ProductType = 1,
            Circulation = "100",
            CopyCount = "10",
            PageCount = "20",
            PrintSide = 1,
            IsDelete = false,
            MinCirculation = 10,
            MaxCirculation = 1000,
            MinPage = 1,
            MaxPage = 200,
            MinWidth = 5.0f,
            MaxWidth = 20.0f,
            MinLength = 5.0f,
            MaxLength = 30.0f,
            SheetDimensionId = 2,
            FileExtension = ".pdf",
            ProductGroupId = 1
        };
        context.Products.Add (product);
        context.SaveChanges ();

        // Act
        var productToUpdate = context.Products.FirstOrDefault (p => p.Id == 1);
        productToUpdate.Circulation = "200";
        productToUpdate.CopyCount = "20";
        context.SaveChanges ();

        // Assert
        var updatedProduct = context.Products.FirstOrDefault (p => p.Id == 1);
        Assert.NotNull (updatedProduct);
        Assert.Equal ("200", updatedProduct.Circulation);
        Assert.Equal ("20", updatedProduct.CopyCount);
    }

    [Fact]
    public void CreateProduct_WithInvalidData_ShouldFailValidation()
    {
        // Arrange
        var product = new Product
        {
            WorkTypeId = 1,
            ProductType = 1,
            Circulation = null // Invalid data
        };

        // Act & Assert
        Assert.Throws<DbUpdateException> (() =>
        {
            var options = GetDbOptions ();
            using var context = new AppDbContext (options);
            context.Products.Add (product);
            context.SaveChanges ();
        });
    }

    [Fact]
    public void CreateProduct_ShouldAddWithProductGroup()
    {
        // Arrange
        var options = GetDbOptions ();
        using var context = new AppDbContext (options);

        var productGroup = new ProductsGroup
        {
            Name = "Group 1",
            WorkType = "Type 1",
            IsDeleted = false
        };

        var product = new Product
        {
            WorkTypeId = 1,
            ProductType = 1,
            Circulation = "100",
            CopyCount = "10",
            PageCount = "20",
            PrintSide = 1,
            IsDelete = false,
            MinCirculation = 10,
            MaxCirculation = 1000,
            MinPage = 1,
            MaxPage = 200,
            MinWidth = 5.0f,
            MaxWidth = 20.0f,
            MinLength = 5.0f,
            MaxLength = 30.0f,
            SheetDimensionId = 2,
            FileExtension = ".pdf",
            ProductGroupId = 1
        };

        // Act
        context.ProductsGroups.Add (productGroup);
        context.Products.Add (product);
        context.SaveChanges ();

        // Assert
        var createdProduct = context.Products
            .AsNoTracking ()
            .Include (p => p.ProductDelivers)
            .Include (p => p.ProductAdts)
            .Include (p => p.ProductMaterials)
            .Include (p => p.ProductPrintKinds)
            .FirstOrDefaultAsync (p => p.Id == product.Id);

        Assert.NotNull (createdProduct);
    }
}