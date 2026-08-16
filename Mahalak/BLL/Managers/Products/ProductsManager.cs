
namespace Mahalak;

public class ProductsManager : IProductsManager
{
  private readonly IUnitOfWork unitOfWork;

  public ProductsManager(IUnitOfWork unitOfWork) =>  this.unitOfWork = unitOfWork;

  public async Task<List<ProductSummaryDTO>> GetPaginatedAsync(
    int pageNumber,int pageSize, CancellationToken ct=default,string name="")
  {
    List<Product> products = await  unitOfWork.ProductsRepository.GetPaginatedAsync(pageNumber,pageSize,name.Trim(),ct);
    return products.Select(p => new ProductSummaryDTO
    {
      Id = p.Id,
      Name = p.Name,
      Price = p.Price,
      Status = p.Status!,
      AddingDate = p.AddingDate,
      //ProductsCount = products.Count,
      ShopId = p.ShopId
    }).ToList();
  }

  public async Task<int> GetCountAsync(string name="",CancellationToken ct=default)
  {
    return await unitOfWork.ProductsRepository.GetCountAsync(name.Trim(),ct);
  }

  public async Task<List<ProductDTO>> GetPaginatedByFiltersAsync(
    int pageNumber,int pageSize,int? countryId, CancellationToken ct=default,
    string name="",
    int categoryId=0,
    decimal minPrice=0,
    decimal maxPrice=0,
    int conditionId=0)
  {
    List<Product> products = await unitOfWork.ProductsRepository.GetPaginatedByFiltersAsync(pageNumber,pageSize,name,categoryId,minPrice,maxPrice,conditionId,countryId,ct);
/*  int index = pageSize * pageNumber - pageSize;
    if (pageSize > products.Count - index)
      pageSize = products.Count - index;
    if (pageSize > products.Count - index)
      pageSize = products.Count - index;*/
    return products.Select(p => new ProductDTO
    {
      Id = p.Id,
      Name = p.Name,
      Price = p.Price,
      Currency = p.Shop!.Country!.Currency,
      Status = p.Status,
      AddingDate = p.AddingDate,
      Category = new PCategoryDTO
      {
        Id = p.CategoryId,
        Name = p.Category?.Name!
      },
      Condition = new PConditionDTO
      {
        Id = p.ConditionId,
        Name = p.Condition?.Name!
      },
      Images = p.Images.Select(img => new ProductImageDTO
      {
          Id = img.Id,
          Name = img.Name,
          ProductId = img.ProductId
      }).ToList(),
      Distinctive=p.Shop!.DistinctiveExpiryDate.ToString() != string.Empty && p.Shop.DistinctiveExpiryDate >= DateTime.Now,
      ProductsCount = products.Count,
      ShopId = p.ShopId
    }).ToList();//.GetRange(index, pageSize);
  }
  
  public async Task<int> GetCountByFiltersAsync(int? countryId,CancellationToken ct=default,string name="",
    int categoryId=0,
    decimal minPrice=0,
    decimal maxPrice=0,
    int conditionId=0)
  {
    return await unitOfWork.ProductsRepository.GetCountByFiltersAsync(name,categoryId,minPrice,maxPrice,conditionId,countryId,ct);
  }


  public async Task<List<ProductSummaryDTO>> GetPaginatedByShopIdAsync(
    int pageNumber,int pageSize,int id, CancellationToken ct=default)
  {
    List<Product> products = await  unitOfWork.ProductsRepository.GetPaginatedByShopIdAsync(pageNumber,pageSize,id,ct);
    return products.Select(p => new ProductSummaryDTO
    {
      Id = p.Id,
      Name = p.Name,
      Price = p.Price,
      Status = p.Status!,
      AddingDate = p.AddingDate,
      //ProductsCount = products.Count,
      ShopId = p.ShopId
    }).ToList();
  }

            public async Task<int> GetCountByShopIdAsync(int id, CancellationToken ct=default)
    {
      return await unitOfWork.ProductsRepository.GetCountByShopIdAsync( id, ct);
    }
  public async Task<ProductDetailsSummaryDTO?> GetDetailsSummaryByIdAsync(int? id,int? countryId)
  {
    var product = await unitOfWork.ProductsRepository.GetDetailsByIdAsync(id,countryId);
    if (product == null)
      return null;
    return new ProductDetailsSummaryDTO
    {
      Id = product.Id,
      Name = product.Name,
      Price = product.Price,
      Category = new PCategoryDTO()
      {
        Id = product.CategoryId,
        Name = product.Category!.Name
      },
      Status = product.Status!,
      Describtion = product.Describtion,
      Condition = new PConditionDTO()
      {
        Id = product.ConditionId,
        Name = product.Condition!.Name
      },
      Images = product.Images.Select(img => new ProductImageDTO
      {
        Id = img.Id,
        Name = img.Name,
        ProductId = img.ProductId
      }).ToList(),
      ShopId = product.ShopId
    };
  }

  public async Task<ProductDetailsDTO?> GetDetailsByIdAsync(int? id,int? countryId)
  {
    var product = await  unitOfWork.ProductsRepository.GetDetailsByIdAsync(id,countryId);
    if (product == null)
      return null;
    return new ProductDetailsDTO
    {
      Id = product.Id,
      Name = product.Name,
      Price = product.Price,
      Currency = product.Shop!.Country!.Currency,
      Category = new PCategoryDTO()
      {
        Id = product.CategoryId,
        Name = product.Category!.Name
      },
      Status = product.Status!,
      Describtion = product.Describtion,
      Condition = new PConditionDTO()
      {
        Id = product.ConditionId,
        Name = product.Condition!.Name
      },
      Images = product.Images.Select(img => new ProductImageDTO
      {
        Id = img.Id,
        Name = img.Name,
        ProductId = img.ProductId
      }).ToList(),
      ShopId = product.ShopId,
      ShopName = product.Shop!.Name
    };
  }

  public async Task<bool> AddAsync(ProductAddDTO productDTO)
  {
     unitOfWork.ProductsRepository.Add(new Product()
    {
      Name = productDTO.Name.Trim(),
      Price = productDTO.Price,
      Describtion = productDTO.Describtion.Trim(),
      AddingDate = DateTime.Now,
      CategoryId = productDTO.CategoryId,
      ConditionId = productDTO.ConditionId,
      ShopId = productDTO.ShopId
    });
    return await  unitOfWork.SaveChangesAsync() != 0;
  }

  public async Task<bool> UpdateAsync(ProductUpdateDTO productDTO)
  {
    var product = await  unitOfWork.ProductsRepository.GetByIdAsync(productDTO.Id);
    if (product == null)
      return false;
    product.Name = productDTO.Name.Trim();
    product.Price = productDTO.Price;
    product.Describtion = productDTO.Describtion.Trim();
    product.CategoryId = productDTO.CategoryId;
    product.ConditionId = productDTO.ConditionId;
    product.Status = productDTO.Status;
     unitOfWork.ProductsRepository.Update(product);
    return await  unitOfWork.SaveChangesAsync() != 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (!await unitOfWork.ProductsRepository.IsExistedAsync(id))
      return false;
     unitOfWork.ProductsRepository.DeleteById(id);
    return await  unitOfWork.SaveChangesAsync() != 0;
  }

  public bool VerifyField(int value) => value != 0;

  public async Task<bool> EditStatusAsync(int id, string status)
  {
    var product = await  unitOfWork.ProductsRepository.GetByIdAsync(id);
    if (product == null)
      return false;
    product.Status = status.Trim();
     unitOfWork.ProductsRepository.Update(product);
    return await  unitOfWork.SaveChangesAsync() != 0;
  }
}
