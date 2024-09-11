using Application.Entities;
using FluentValidation;

namespace Endpoint.Api.Validators;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor (x => x.ProductGroupId).GreaterThan (0).WithMessage ("ProductGroupId must be greater than 0.");
        RuleFor (x => x.WorkTypeId).GreaterThan (0).WithMessage ("WorkTypeId must be greater than 0.");
        RuleFor (x => x.ProductType).InclusiveBetween ((byte)0, (byte)2)
            .WithMessage ("ProductType must be a valid byte value.");

        RuleFor (x => x.Circulation).NotEmpty ().WithMessage ("Circulation is required.");
        RuleFor (x => x.CopyCount).NotEmpty ().WithMessage ("CopyCount is required.");
        RuleFor (x => x.PageCount).NotEmpty ().WithMessage ("PageCount is required.");
        RuleFor (x => x.PrintSide).InclusiveBetween ((byte)0, (byte)2)
            .WithMessage ("PrintSide must be 0 (Single) or 1 (Double).");
        RuleFor (x => x.SheetDimensionId).GreaterThan (0).WithMessage ("SheetDimensionId must be greater than 0.");
        RuleFor (x => x.FileExtension).MaximumLength (50)
            .WithMessage ("FileExtension cannot be longer than 50 characters.");
        RuleFor (x => x.CutMargin).GreaterThanOrEqualTo (0)
            .WithMessage ("CutMargin must be greater than or equal to 0.");
        RuleFor (x => x.PrintMargin).GreaterThanOrEqualTo (0)
            .WithMessage ("PrintMargin must be greater than or equal to 0.");

        RuleForEach (x => x.ProductAdts).SetValidator (new ProductAdtDtoValidator ());
        RuleForEach (x => x.ProductDelivers).SetValidator (new ProductDeliverDtoValidator ());
        RuleForEach (x => x.ProductMaterials).SetValidator (new ProductMaterialDtoValidator ());
        RuleForEach (x => x.ProductOptionals).SetValidator (new ProductOptionalDtoValidator ());
        RuleForEach (x => x.ProductSizes).SetValidator (new ProductSizeDtoValidator ());
        RuleForEach (x => x.ProductPrintKinds).SetValidator (new ProductPrintKindDtoValidator ());
        RuleForEach (x => x.ProductPrices).SetValidator (new ProductPriceDtoValidator ());
    }
}

public class ProductJeldDtoValidator : AbstractValidator<ProductJeldDto>
{
    public ProductJeldDtoValidator()
    {
        RuleFor (x => x.PrintSide).InclusiveBetween ((byte)0, (byte)2)
            .WithMessage ("PrintSide must be between 0 and 2 (Single or Double).");
        RuleFor (x => x.FileExtension).MaximumLength (50)
            .WithMessage ("FileExtension cannot be longer than 50 characters.");
        RuleFor (x => x.CutMargin).GreaterThanOrEqualTo (0)
            .WithMessage ("CutMargin must be greater than or equal to 0.");
        RuleFor (x => x.PrintMargin).GreaterThanOrEqualTo (0)
            .WithMessage ("PrintMargin must be greater than or equal to 0.");
    }
}

public class ProductAdtDtoValidator : AbstractValidator<ProductAdtDto>
{
    public ProductAdtDtoValidator()
    {
        RuleFor (x => x.AdtId).GreaterThan (0).WithMessage ("AdtId must be greater than 0.");
        RuleFor (x => x.Count).GreaterThanOrEqualTo (0).When (x => x.Count.HasValue)
            .WithMessage ("Count must be greater than or equal to 0.");
        RuleForEach (x => x.AdtTypes).SetValidator (new ProductAdtTypeDtoValidator ());
        RuleForEach (x => x.AdtPrices).SetValidator (new ProductAdtPriceDtoValidator ());
    }
}

public class ProductAdtTypeDtoValidator : AbstractValidator<ProductAdtTypeDto>
{
    public ProductAdtTypeDtoValidator()
    {
        RuleFor (x => x.AdtTypeId).GreaterThan (0).WithMessage ("AdtTypeId must be greater than 0.");
    }
}

public class ProductAdtPriceDtoValidator : AbstractValidator<ProductAdtPriceDto>
{
    public ProductAdtPriceDtoValidator()
    {
        RuleFor (x => x.Price).GreaterThanOrEqualTo (0).WithMessage ("Price must be greater than or equal to 0.");
        RuleFor (x => x.ProductAdtTypeId).GreaterThan (0).WithMessage ("ProductAdtTypeId must be greater than 0.");
    }
}

public class ProductDeliverDtoValidator : AbstractValidator<ProductDeliverDto>
{
    public ProductDeliverDtoValidator()
    {
        RuleFor (x => x.Name).NotEmpty ().WithMessage ("Name is required.");
        RuleFor (x => x.StartCirculation).GreaterThanOrEqualTo (0)
            .WithMessage ("StartCirculation must be greater than or equal to 0.");
        RuleFor (x => x.EndCirculation).GreaterThanOrEqualTo (x => x.StartCirculation)
            .WithMessage ("EndCirculation must be greater than or equal to StartCirculation.");
        RuleFor (x => x.Price).GreaterThanOrEqualTo (0).WithMessage ("Price must be greater than or equal to 0.");
    }
}

public class ProductMaterialDtoValidator : AbstractValidator<ProductMaterialDto>
{
    public ProductMaterialDtoValidator()
    {
        RuleFor (x => x.Name).NotEmpty ().WithMessage ("Name is required.");
        RuleFor (x => x.Weight).GreaterThanOrEqualTo (0).When (x => x.Weight.HasValue)
            .WithMessage ("Weight must be greater than or equal to 0.");
    }
}

public class ProductOptionalDtoValidator : AbstractValidator<ProductOptionalDto>
{
    public ProductOptionalDtoValidator()
    {
        RuleFor (x => x.Name).NotEmpty ().WithMessage ("Name is required.");
        RuleForEach (x => x.Details).SetValidator (new ProductOptionalDetailDtoValidator ());
    }
}

public class ProductOptionalDetailDtoValidator : AbstractValidator<ProductOptionalDetailDto>
{
    public ProductOptionalDetailDtoValidator()
    {
        RuleFor (x => x.Name).NotEmpty ().WithMessage ("Name is required.");
    }
}

public class ProductSizeDtoValidator : AbstractValidator<ProductSizeDto>
{
    public ProductSizeDtoValidator()
    {
        RuleFor (x => x.Length).GreaterThan (0).WithMessage ("Length must be greater than 0.");
        RuleFor (x => x.Width).GreaterThan (0).WithMessage ("Width must be greater than 0.");
        RuleFor (x => x.Name).NotEmpty ().WithMessage ("Name is required.");
    }
}

public class ProductPrintKindDtoValidator : AbstractValidator<ProductPrintKindDto>
{
    public ProductPrintKindDtoValidator()
    {
        RuleFor (x => x.PrintKindId).GreaterThan (0).WithMessage ("PrintKindId must be greater than 0.");
    }
}

public class ProductPriceDtoValidator : AbstractValidator<ProductPriceDto>
{
    public ProductPriceDtoValidator()
    {
        RuleFor (x => x.Price).GreaterThanOrEqualTo (0).WithMessage ("Price must be greater than or equal to 0.");
        RuleFor (x => x.Circulation).GreaterThan (0).WithMessage ("Circulation must be greater than 0.");
        RuleFor (x => x.ProductSizeId).GreaterThan (0).WithMessage ("ProductSizeId must be greater than 0.");
        // RuleFor (x => x.ProductMaterialId).GreaterThan (0).WithMessage ("ProductMaterialId must be greater than 0.");
        // RuleFor (x => x.ProductPrintKindId).GreaterThan (0).WithMessage ("ProductPrintKindId must be greater than 0.");
    }
}