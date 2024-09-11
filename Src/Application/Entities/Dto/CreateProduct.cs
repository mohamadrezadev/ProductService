namespace Application.Entities;

public class ProductCreateDto
{
    
    public int? Id { get; set; }

    public int? ProductGroupId { get; set; }
    public int WorkTypeId { get; set; }
    public byte ProductType { get; set; }
    public string Circulation { get; set; }
    public string CopyCount { get; set; }
    public string PageCount { get; set; }
    public byte PrintSide { get; set; }
    public bool IsDelete { get; set; }
    public bool IsCalculatePrice { get; set; }
    public bool IsCustomCirculation { get; set; }
    public bool IsCustomSize { get; set; }
    public bool IsCustomPage { get; set; }
    public int? MinCirculation { get; set; }
    public int? MaxCirculation { get; set; }
    public int? MinPage { get; set; }
    public int? MaxPage { get; set; }
    public float? MinWidth { get; set; }
    public float? MaxWidth { get; set; }
    public float? MinLength { get; set; }
    public float? MaxLength { get; set; }
    public int SheetDimensionId { get; set; }
    public string FileExtension { get; set; }
    public bool IsCmyk { get; set; }
    public float CutMargin { get; set; }
    public float PrintMargin { get; set; }
    public bool IsCheckFile { get; set; }

    public ProductJeldDto ProductJeld { get; set; }
    public List<ProductAdtDto> ProductAdts { get; set; }
    public List<ProductDeliverDto> ProductDelivers { get; set; }
    public List<ProductMaterialDto> ProductMaterials { get; set; }
    public List<ProductOptionalDto> ProductOptionals { get; set; }
    public List<ProductSizeDto> ProductSizes { get; set; }
    public List<ProductPrintKindDto> ProductPrintKinds { get; set; }
    public List<ProductPriceDto> ProductPrices { get; set; }
}

public class ProductJeldDto
{
    public byte PrintSide { get; set; }
    public string FileExtension { get; set; }
    public bool IsCmyk { get; set; }
    public float? CutMargin { get; set; }
    public float? PrintMargin { get; set; }
    public bool IsCheckFile { get; set; }
}

public class ProductAdtDto
{
    public int AdtId { get; set; }
    public bool Required { get; set; }
    public byte? Side { get; set; }
    public int? Count { get; set; }
    public bool IsJeld { get; set; }
    public List<ProductAdtTypeDto> AdtTypes { get; set; }
    public List<ProductAdtPriceDto> AdtPrices { get; set; }
}

public class ProductAdtTypeDto
{
    public int AdtTypeId { get; set; }
}

public class ProductAdtPriceDto
{
    public float Price { get; set; }
    public int ProductAdtTypeId { get; set; }
}

public class ProductDeliverDto
{
    public string Name { get; set; }
    public bool IsIncreased { get; set; }
    public int StartCirculation { get; set; }
    public int EndCirculation { get; set; }
    public byte PrintSide { get; set; }
    public float Price { get; set; }
    public byte CalcType { get; set; }
    public List<int> ProductSizeIds { get; set; }
}

public class ProductMaterialDto
{
    // public int MaterialId { get; set; }
    public string Name { get; set; }
    public bool IsJeld { get; set; }
    public bool Required { get; set; }
    public bool IsCustomCirculation { get; set; }
    public bool IsCombinedMaterial { get; set; }
    public List<int> MaterialAttributeIds { get; set; }
    public int? Weight { get; set; }
}

public class ProductOptionalDto
{
    public string Name { get; set; }
    public byte Type { get; set; }
    public List<ProductOptionalDetailDto> Details { get; set; }
}

public class ProductOptionalDetailDto
{
    public string Name { get; set; }
}

public class ProductSizeDto
{
    public float Length { get; set; }
    public float Width { get; set; }
    public string Name { get; set; }
    public int? SheetCount { get; set; }
    public int? SheetDimensionId { get; set; }
}

public class ProductPrintKindDto
{
    public int PrintKindId { get; set; }
    public bool IsJeld { get; set; }
}

public class ProductPriceDto
{
    // public int Id { get; set; }
    public float Price { get; set; }
    public int Circulation { get; set; }
    public bool IsDoubleSided { get; set; }
    public int? PageCount { get; set; }
    public int? CopyCount { get; set; }
    public int ProductSizeId { get; set; }
    // public int ProductMaterialId { get; set; }
    public int? ProductMaterialAttributeId { get; set; }
    public bool IsJeld { get; set; }
    // public int ProductPrintKindId { get; set; }
}