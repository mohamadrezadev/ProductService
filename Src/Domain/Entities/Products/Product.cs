using Domain.Common;

public class Product:IEntity
{
    public int Id { get; set; }
    public int WorkTypeId { get; set; }
    public byte ProductType { get; set; }
    public string Circulation { get; set; }
    public string CopyCount { get; set; }
    public string PageCount { get; set; }
    public byte PrintSide { get; set; }
    public bool IsDelete { get; set; } = false;
    public bool IsCalculatePrice { get; set; } = true;
    public bool IsCustomCirculation { get; set; } = false;
    public bool IsCustomSize { get; set; } = false;
    public bool IsCustomPage { get; set; } = false;
    public int MinCirculation { get; set; }
    public int MaxCirculation { get; set; }
    public int MinPage { get; set; }
    public int MaxPage { get; set; }
    public float MinWidth { get; set; }
    public float MaxWidth { get; set; }
    public float MinLength { get; set; }
    public float MaxLength { get; set; }
    public int SheetDimensionId { get; set; }
    public string FileExtension { get; set; }
    public bool IsCmyk { get; set; } = false;
    public float CutMargin { get; set; } = 0;
    public float PrintMargin { get; set; } = 0;
    public bool IsCheckFile { get; set; }

    public ICollection<ProductAdt> ProductAdts { get; set; }
    public ICollection<ProductDeliver> ProductDelivers { get; set; }
    public ICollection<ProductMaterial> ProductMaterials { get; set; }
    public ICollection<ProductPrintKind> ProductPrintKinds { get; set; }
    public ICollection<ProductSize> ProductSizes { get; set; }
    
    public int? ProductGroupId { get; set; }
    public ProductsGroup? ProductsGroup { get; set; }
    
}

public class ProductsGroup : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string WorkType { get; set; }
    public bool IsDeleted { get; set; }
    public bool enable  { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product> ();


}

public class ProductAdt:IEntity
{
    public int Id { get; set; }
    public int AdtId { get; set; }
    public int ProductId { get; set; }
    public bool Required { get; set; } = false;
    public byte Side { get; set; }
    public int Count { get; set; }
    public bool IsJeld { get; set; } = false;

    public Product Product { get; set; }
    public ICollection<ProductAdtPrice> ProductAdtPrices { get; set; }
    public ICollection<ProductAdtType> ProductAdtTypes { get; set; }
}

public class ProductAdtPrice:IEntity
{
    public int Id { get; set; }
    public int ProductAdtId { get; set; }
    public float Price { get; set; }
    public int ProductPriceId { get; set; }
    public int ProductAdtTypeId { get; set; }

    public ProductAdt ProductAdt { get; set; }
}

public class ProductAdtType:IEntity
{
    public int Id { get; set; }
    public int ProductAdtId { get; set; }
    public int AdtTypeId { get; set; }

    public ProductAdt ProductAdt { get; set; }
}

public class ProductDeliver:IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public bool IsIncreased { get; set; } = true;
    public int StartCirculation { get; set; }
    public int EndCirculation { get; set; }
    public byte PrintSide { get; set; }
    public float Price { get; set; }
    public byte CalcType { get; set; }

    public Product Product { get; set; }
    public ICollection<ProductDeliverSize> ProductDeliverSizes { get; set; }
}

public class ProductDeliverSize:IEntity
{
    public int Id { get; set; }
    public int ProductSizeId { get; set; }
    public int ProductDeliverId { get; set; }

    public ProductDeliver ProductDeliver { get; set; }
}

public class ProductJeld:IEntity
{
    public bool Id { get; set; }
    public int ProductId { get; set; }
    public byte PrintSide { get; set; }
    public string FileExtension { get; set; }
    public bool IsCmyk { get; set; } = false;
    public float CutMargin { get; set; }
    public float PrintMargin { get; set; }
    public bool IsCheckFile { get; set; } = false;
}

public class ProductMaterial:IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int MaterialId { get; set; }
    public string Name { get; set; }
    public bool IsJeld { get; set; } = false;
    public bool Required { get; set; } = false;
    public bool IsCustomCirculation { get; set; } = false;
    public bool IsCombinedMaterial { get; set; } = false;
    public int Weight { get; set; }

    public Product Product { get; set; }
    public ICollection<ProductMaterialAttribute> ProductMaterialAttributes { get; set; }
}

public class ProductMaterialAttribute:IEntity
{
    public int Id { get; set; }
    public int ProductMaterialId { get; set; }
    public int MaterialAttributeId { get; set; }

    public ProductMaterial ProductMaterial { get; set; }
}

public class ProductPrice:IEntity
{
    public int Id { get; set; }
    public float Price { get; set; }
    public int Circulation { get; set; }
    public bool IsDoubleSided { get; set; }
    public int PageCount { get; set; }
    public int CopyCount { get; set; }
    public int ProductSizeId { get; set; }
    public int ProductMaterialId { get; set; }
    public int ProductMaterialAttributeId { get; set; }
    public bool IsJeld { get; set; } = false;
    public int ProductPrintKindId { get; set; }
}

public class ProductPrintKind:IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int PrintKindId { get; set; }
    public bool IsJeld { get; set; } = false;

    public Product Product { get; set; }
}

public class ProductSize:IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public float Length { get; set; }
    public float Width { get; set; }
    public string Name { get; set; }
    public int SheetCount { get; set; }
    public int SheetDimensionId { get; set; }

    public Product Product { get; set; }
}