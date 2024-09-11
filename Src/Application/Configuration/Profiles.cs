using Application.Entities;
using AutoMapper;

namespace Application.Configuration
{
    public class Profiles  :Profile
    {
        public Profiles()
        {
        
            // Map ProductCreateDto to Product and vice versa
            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id for Create mapping
                .ReverseMap();

            CreateMap<ProductDto, Product> ()
                .ReverseMap ();


            // Map ProductJeldDto to ProductJeld and vice versa
            CreateMap<ProductJeldDto, ProductJeld>()
                .ReverseMap();

            // Map ProductAdtDto to ProductAdt and vice versa
            CreateMap<ProductAdtDto, ProductAdt>()
                .ReverseMap();

            // Map ProductAdtTypeDto to ProductAdtType and vice versa
            CreateMap<ProductAdtTypeDto, ProductAdtType>()
                .ReverseMap();

            // Map ProductAdtPriceDto to ProductAdtPrice and vice versa
            CreateMap<ProductAdtPriceDto, ProductAdtPrice>()
                .ReverseMap();

            // Map ProductDeliverDto to ProductDeliver and vice versa
            CreateMap<ProductDeliverDto, ProductDeliver>()
                .ReverseMap();

            // Map ProductMaterialDto to ProductMaterial and vice versa
            CreateMap<ProductMaterialDto, ProductMaterial>()
                .ReverseMap();

            // Map ProductSizeDto to ProductSize and vice versa
            CreateMap<ProductSizeDto, ProductSize>()
                .ReverseMap();

            // Map ProductPrintKindDto to ProductPrintKind and vice versa
            CreateMap<ProductPrintKindDto, ProductPrintKind>()
                .ReverseMap();

            // Map ProductPriceDto to ProductPrice and vice versa
            CreateMap<ProductPriceDto, ProductPrice>()
                .ReverseMap();
        }
    }
}
