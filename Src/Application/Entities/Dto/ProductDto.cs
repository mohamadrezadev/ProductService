namespace Application.Entities;

public class ProductDto
{
    public int Id { get; set; }
    public int ProductGroupId { get; set; }
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