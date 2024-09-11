using Application.Interface;
using Application.Utils;
using Microsoft.EntityFrameworkCore;
using Persistances.Common;
using Persistances.Data;

namespace Persistances.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository (AppDbContext dbContext) : base (dbContext)
        {
        }

        public async Task<DefaultResult<Product>> AddNewOrUpdate (Product product)
        {
            var existingProduct = await DbContext.Products
                .AsNoTracking ()
                .Include (p => p.ProductDelivers)
                .Include (p => p.ProductAdts)
                .Include (p => p.ProductMaterials)
                .Include (p => p.ProductPrintKinds)
                .FirstOrDefaultAsync (p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Circulation = product.Circulation;
                existingProduct.CopyCount = product.CopyCount;
                existingProduct.PageCount = product.PageCount;
                existingProduct.PrintSide = product.PrintSide;
                existingProduct.IsDelete = product.IsDelete;
                existingProduct.IsCalculatePrice = product.IsCalculatePrice;
                existingProduct.IsCustomCirculation = product.IsCustomCirculation;
                existingProduct.IsCustomSize = product.IsCustomSize;
                existingProduct.IsCustomPage = product.IsCustomPage;
                existingProduct.MinCirculation = product.MinCirculation;
                existingProduct.MaxCirculation = product.MaxCirculation;
                existingProduct.MinPage = product.MinPage;
                existingProduct.MaxPage = product.MaxPage;
                existingProduct.MinWidth = product.MinWidth;
                existingProduct.MaxWidth = product.MaxWidth;
                existingProduct.MinLength = product.MinLength;
                existingProduct.MaxLength = product.MaxLength;
                existingProduct.SheetDimensionId = product.SheetDimensionId;
                existingProduct.FileExtension = product.FileExtension;
                existingProduct.IsCmyk = product.IsCmyk;
                existingProduct.CutMargin = product.CutMargin;
                existingProduct.PrintMargin = product.PrintMargin;
                existingProduct.IsCheckFile = product.IsCheckFile;
                existingProduct.ProductAdts = product.ProductAdts;
                existingProduct.ProductDelivers = product.ProductDelivers;
                existingProduct.ProductMaterials = product.ProductMaterials;
                existingProduct.ProductPrintKinds = product.ProductPrintKinds;
                DbContext.Products.Update (existingProduct);
                await DbContext.SaveChangesAsync ();
                return DefaultResult<Product>.Success (ResultMessages.Updated, existingProduct);
            }
            if (product.ProductGroupId.HasValue)
            {
                var productGroup = await DbContext.ProductsGroups.FindAsync(product.ProductGroupId.Value);
                if (productGroup != null)
                {
                    product.ProductGroupId = productGroup.Id;
                    product.ProductsGroup = productGroup;
                }
                else
                {
                    product.ProductGroupId = null;
                }
                    
            }
                
            await DbContext.Products.AddAsync (product);
            await DbContext.SaveChangesAsync ();
            return DefaultResult<Product>.Success (ResultMessages.Created, product);
        }
        
    }
}

