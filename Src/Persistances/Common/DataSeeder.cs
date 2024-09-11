using Application.Interface;
using Persistances.Data;

namespace Persistances.Common;

public class DataSeeder(IProductRepository productRepository,
    AppDbContext context)
{
    public async Task SeddProduct(int countforSeed)
    {
        var result = context.Products.ToList ();
        if (result.Count () > 0)
            return;

        for (int i = 1; i <= countforSeed; i++)
        {
            Product product = new ()
            {
                WorkTypeId = 1,
                ProductType = 1,
                Circulation = "1000",
                CopyCount = "100",
                PageCount = "10",
                PrintSide = 1,
                IsDelete = false,
                IsCalculatePrice = true,
                IsCustomCirculation = false,
                IsCustomSize = false,
                IsCustomPage = false,
                MinCirculation = 100,
                MaxCirculation = 2000,
                MinPage = 1,
                MaxPage = 100,
                MinWidth = 10.0f,
                MaxWidth = 50.0f,
                MinLength = 20.0f,
                MaxLength = 100.0f,
                SheetDimensionId = 1,
                FileExtension = $".pdf",
                IsCmyk = true,
                CutMargin = 0.5f,
                PrintMargin = 1.0f,
                IsCheckFile = true
            };
           await  productRepository.AddAsync (product, CancellationToken.None);

        }
    }
}