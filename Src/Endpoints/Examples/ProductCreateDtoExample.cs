using Application.Entities;
using Swashbuckle.AspNetCore.Filters;

namespace Endpoint.Api.Examples;

public class ProductCreateDtoExample : IExamplesProvider<ProductCreateDto>
{
    public ProductCreateDto GetExamples()
    {
        return new ProductCreateDto
        {
            Id=5,
            ProductGroupId = 1,
            WorkTypeId = 2,
            ProductType = 0,
            Circulation = "500",
            CopyCount = "10",
            PageCount = "20",
            PrintSide = 1,
            IsDelete = false,
            IsCalculatePrice = true,
            IsCustomCirculation = false,
            IsCustomSize = true,
            IsCustomPage = false,
            MinCirculation = 100,
            MaxCirculation = 1000,
            MinPage = 10,
            MaxPage = 50,
            MinWidth = 5.5f,
            MaxWidth = 15.0f,
            MinLength = 10.0f,
            MaxLength = 25.0f,
            SheetDimensionId = 1,
            FileExtension = ".pdf",
            IsCmyk = true,
            CutMargin = 0.5f,
            PrintMargin = 0.5f,
            IsCheckFile = true,
            ProductJeld = new ProductJeldDto
            {
                PrintSide = 1,
                FileExtension = ".pdf",
                IsCmyk = true,
                CutMargin = 0.5f,
                PrintMargin = 0.5f,
                IsCheckFile = true
            },
            ProductAdts = new List<ProductAdtDto>
            {
                new ProductAdtDto
                {
                    AdtId = 1,
                    Required = true,
                    Side = 1,
                    Count = 100,
                    IsJeld = true,
                    AdtTypes = new List<ProductAdtTypeDto>
                    {
                        new ProductAdtTypeDto { AdtTypeId = 1 }
                    },
                    AdtPrices = new List<ProductAdtPriceDto>
                    {
                        new ProductAdtPriceDto { Price = 12.5f, ProductAdtTypeId = 1 }
                    }
                }
            },
            ProductDelivers = new List<ProductDeliverDto>
            {
                new ProductDeliverDto
                {
                    Name = "Delivery Option 1",
                    IsIncreased = true,
                    StartCirculation = 100,
                    EndCirculation = 500,
                    PrintSide = 1,
                    Price = 50.0f,
                    CalcType = 1,
                    ProductSizeIds = new List<int> { 1, 2 }
                }
            },
            ProductMaterials = new List<ProductMaterialDto>
            {
                new ProductMaterialDto
                {
                    // MaterialId = 1,
                    Name = "Material 1",
                    IsJeld = false,
                    Required = true,
                    IsCustomCirculation = false,
                    IsCombinedMaterial = false,
                    MaterialAttributeIds = new List<int> { 1, 2 },
                    Weight = 200
                }
            },
            ProductOptionals = new List<ProductOptionalDto>
            {
                new ProductOptionalDto
                {
                    Name = "Optional 1",
                    Type = 1,
                    Details = new List<ProductOptionalDetailDto>
                    {
                        new ProductOptionalDetailDto { Name = "Detail 1" }
                    }
                }
            },
            ProductSizes = new List<ProductSizeDto>
            {
                new ProductSizeDto
                {
                    Length = 30.0f,
                    Width = 20.0f,
                    Name = "Size 1",
                    SheetCount = 2,
                    SheetDimensionId = 1
                }
            },
            ProductPrintKinds = new List<ProductPrintKindDto>
            {
                new ProductPrintKindDto
                {
                    PrintKindId = 1,
                    IsJeld = false
                }
            },
            ProductPrices = new List<ProductPriceDto>
            {
                new ProductPriceDto
                {
                    // Id = 1,
                    Price = 100.0f,
                    Circulation = 500,
                    IsDoubleSided = true,
                    PageCount = 20,
                    CopyCount = 10,
                    ProductSizeId = 1,
                    // ProductMaterialId = 1,
                    ProductMaterialAttributeId = null,
                    IsJeld = false,
                    // ProductPrintKindId = 1
                }
            }
        };
    }
}
