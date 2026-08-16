namespace Mahalak;
public class ShopsManager : IShopsManager
{
  private readonly IUnitOfWork unitOfWork;

  public ShopsManager(IUnitOfWork unitOfWork) =>  this.unitOfWork = unitOfWork;

  public async Task<List<ShopSummaryDTO>> GetPaginatedAsync(int pageNumber,int pageSize, CancellationToken ct=default)
  {
    List<Shop> shops = await  unitOfWork.ShopsRepository.GetPaginatedAsync(pageNumber,pageSize,ct);
/*    int index = pageSize * pageNumber - pageSize;
    if (pageSize > shops.Count - index)
      pageSize = shops.Count - index;
    if (pageNumber > pageSize)
      pageNumber = pageSize;*/
      
    return shops.Select(s => new ShopSummaryDTO
    {
      Id = s.Id,
      Name = s.Name,
      Status = s.Status!,
      Distinctive = s.DistinctiveExpiryDate.ToString() != string.Empty && s.DistinctiveExpiryDate >= DateTime.Now,
      DistinctiveExpiryDate = s.DistinctiveExpiryDate,
      MaxProductNum = s.MaxProductNum,
      CreatingDate = s.CreatingDate,
      UserId = s.UserId
    }).ToList();//.GetRange(index, pageSize);
  }

          public async Task<int> GetCountAsync(CancellationToken ct=default)
    {
      return await unitOfWork.ShopsRepository.GetCountAsync(ct);
    }

  public async Task<List<ShopDTO>> GetPaginatedByFiltersAsync(int pageNumber,int pageSize,
        int categoryId=0,
    int countryId=0,
    int cityId=0,
    int areaId=0, CancellationToken ct=default)
  {
    List<Shop> shops = await unitOfWork.ShopsRepository.GetPaginatedByFiltersAsync(pageNumber,pageSize,categoryId, countryId, cityId, areaId,ct);
/*    int index = pageSize * pageNumber - pageSize;
    if (pageSize > shops.Count - index)
      pageSize = shops.Count - index;*/
    return shops.Select(s => new ShopDTO
    {
      Id = s.Id,
      Name = s.Name,
      CategoryId = s.CategoryId,
      CountryId = s.CountryId,
      CityId = s.CityId,
      AreaId = s.AreaId,
      Status = s.Status!,
      TotalRaters = s.Ratings.Count,
      Distinctive = s.DistinctiveExpiryDate.ToString() != string.Empty && s.DistinctiveExpiryDate >= DateTime.Now,
      DistinctiveExpiryDate = s.DistinctiveExpiryDate,
      MaxProductNum = s.MaxProductNum,
      CreatingDate = s.CreatingDate,
      ShopsCount = shops.Count,
      UserId = s.UserId
    }).ToList();//.GetRange(index, pageSize);
  }

        public async Task<int> GetCountByFiltersAsync(int categoryId=0,
    int countryId=0,
    int cityId=0,
    int areaId=0, CancellationToken ct=default)
    {
      return await unitOfWork.ShopsRepository.GetCountByFiltersAsync(categoryId,countryId,cityId,areaId,ct);
    }

  public async Task<List<ShopSummaryDTO>> GetPaginatedByUserIdAsync(
    int pageNumber,int pageSize,string id, CancellationToken ct=default)
  {
    List<Shop> shops = await  unitOfWork.ShopsRepository.GetPaginatedByUserIdAsync(pageNumber,pageSize,id,ct);
/*    int index = pageSize * pageNumber - pageSize;
    if (pageSize > shops.Count - index)
      pageSize = shops.Count - index;*/
    return shops.Select(s => new ShopSummaryDTO
    {
      Id = s.Id,
      Name = s.Name,
      Status = s.Status!,
      Distinctive = s.DistinctiveExpiryDate.ToString() != string.Empty && s.DistinctiveExpiryDate >= DateTime.Now,
      DistinctiveExpiryDate = s.DistinctiveExpiryDate,
      MaxProductNum = s.MaxProductNum,
      CreatingDate = s.CreatingDate,
      UserId = s.UserId
    }).ToList();//.GetRange(index, pageSize);
  }

          public async Task<int> GetCountByUserIdAsync(string id, CancellationToken ct=default)
    {
      return await unitOfWork.ShopsRepository.GetCountByUserIdAsync(id,ct);
    }

  public async Task<List<ShopSummaryDTO>> GetPaginatedByNameAsync(
    int pageNumber,int pageSize,string name, CancellationToken ct=default)
  {
    List<Shop> shops = await  unitOfWork.ShopsRepository.GetPaginatedByNameAsync(pageNumber,pageSize,name.Trim(),ct);
/*    int index = pageSize * pageNumber - pageSize;
    if (pageSize > shops.Count - index)
      pageSize = shops.Count - index;*/
    return shops.Select(s => new ShopSummaryDTO
    {
      Id = s.Id,
      Name = s.Name,
      Status = s.Status!,
      Distinctive = s.DistinctiveExpiryDate.ToString() != string.Empty && s.DistinctiveExpiryDate >= DateTime.Now,
      DistinctiveExpiryDate = s.DistinctiveExpiryDate,
      MaxProductNum = s.MaxProductNum,
      CreatingDate = s.CreatingDate,
      UserId = s.UserId
    }).ToList();//.GetRange(index, pageSize);
  }

          public async Task<int> GetCountByNameAsync(string name, CancellationToken ct=default)
    {
      return await unitOfWork.ShopsRepository.GetCountByNameAsync(name.Trim(),ct);
    }

  public async Task<ShopDetailsSummaryDTO?> GetByIdAsync(int? id, CancellationToken ct=default)
  {
    var shop = await  unitOfWork.ShopsRepository.GetByIdAsync(id);
    if (shop == null)
      return null;
    int productsCount = await unitOfWork.ProductsRepository.GetCountByShopIdAsync(id!.Value,ct);
    return new ShopDetailsSummaryDTO
    {
      Id = shop.Id,
      Name = shop.Name,
      CategoryId = shop.CategoryId,
      Status = shop.Status!,
      //Distinctive = shop.Distinctive,
      DistinctiveExpiryDate = shop.DistinctiveExpiryDate,
      MaxProductNum = shop.MaxProductNum,
      CreatingDate = shop.CreatingDate,
      ProductsCount = productsCount,
      UserId = shop.UserId
    };
  }

  public async Task<ShopDetailsDTO?> GetDetailsByIdAsync(int? id,int? countryId)
  {
    var shop = await  unitOfWork.ShopsRepository.GetDetailsByIdAsync(id,countryId);
    if (shop == null)
      return null;
    return new ShopDetailsDTO
    {
      Id = shop.Id,
      Name = shop.Name,
      Status = shop.Status!,
      User = new UserDTO
      {
        Id = shop.UserId,
        FirstName = shop.User?.FirstName!,
        LastName = shop.User?.LastName!,
        Email = shop.User?.Email!,
        PhoneNumber = shop.User?.PhoneNumber!
      },
/*      ClientsRatings = shop.Ratings.Select(r => new RatingDTO
      {
        Id = r.Id,
        UserName = r.User!.FirstName+" "+r.User!.LastName,
        Value = r.Value,
        Comment = r.Comment,
        Status = r.Status!,
        CommentDatetime = r.CommentDatetime?.ToString("dddd, dd MMMM yyyy h:mm tt")!,
        ShopId = r.ShopId,
        UserId = r.UserId
      }).ToList(),*/
      Category = new SCategoryDTO
      {
        Id = shop.CategoryId,
        Name = shop.Category?.Name!
      },
      Country = new SCountryDTO
      {
        Id = shop.CountryId,
        Name = shop.Country?.Name!
      },
      City = new SCityDTO
      {
        Id = shop.CityId,
        Name = shop.City?.Name!
      },
      Area = new SAreaDTO
      {
        Id = shop.AreaId,
        Name = shop.Area?.Name!
      },
      Products = shop.Products.Select(p => new ProductInShopDTO
      {
        Id = p.Id,
        Name = p.Name,
        Images = p.Images.Select(img => new ProductImageDTO
        {
          Id = img.Id,
          Name = img.Name,
          ProductId = img.ProductId
        }).ToList()
      }).ToList()
    };
  }

  public async Task<bool> AddAsync(ShopAddDTO shopDTO)
  {
     unitOfWork.ShopsRepository.Add(new Shop
    {
      Name = shopDTO.Name.Trim(),
      CategoryId = shopDTO.CategoryId,
      CountryId = shopDTO.CountryId,
      CityId = shopDTO.CityId,
      AreaId = shopDTO.AreaId,
      CreatingDate = DateTime.Now,
      MaxProductNum= 6,
      UserId = shopDTO.UserId!
    });
    return await  unitOfWork.SaveChangesAsync() != 0;
  }

  public async Task<bool> UpdateAsync(ShopUpdateDTO shopDTO)
  {
    var shop = await unitOfWork.ShopsRepository.GetByIdAsync(shopDTO.Id);
    if (shop == null)
      return false;
    shop.Name = shopDTO.Name.Trim();
    shop.CategoryId = shopDTO.CategoryId;
    shop.Status = shopDTO.Status;
     unitOfWork.ShopsRepository.Update(shop);
    return await  unitOfWork.SaveChangesAsync() != 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (await unitOfWork.ShopsRepository.IsExistedAsync(id)==null)
      return false;
     unitOfWork.ShopsRepository.DeleteById(id);
    return await  unitOfWork.SaveChangesAsync() != 0;
  }

  public async Task<bool> VerifyFieldAsync(string value, CancellationToken ct=default)
  {
    List<Shop> allAsync = await unitOfWork.ShopsRepository.GetAllAsync(ct);
    for (int index = 0; index < allAsync.Count; ++index)
    {
      if (allAsync[index].Name == value.Trim())
        return false;
    }
    return true;
  }

  public async Task<bool> VerifyEditFieldAsync(string value, int? id, CancellationToken ct=default)
  {
    List<Shop> shops = await unitOfWork.ShopsRepository.GetAllAsync(ct);
    var shop = await unitOfWork.ShopsRepository.GetByIdAsync(id);
    if (shop != null)
    {
      for (int index = 0; index < shops.Count; ++index)
      {
        if (shop.Name != value.Trim() && shops[index].Name == value)
          return false;
      }
    }
    return true;
  }

  public bool VerifyField(int value) => value != 0;

  public async  Task<bool> EditStatusAsync(int id, string status)
  {
    var shop = await unitOfWork.ShopsRepository.GetByIdAsync(id);
    if (shop == null)
      return false;
    shop.Status = status.Trim();
     unitOfWork.ShopsRepository.Update(shop);
    return await  unitOfWork.SaveChangesAsync() != 0;
  }

  public async  Task<bool> EditDistinctiveAsync(int id, int period)
  {
    var shop = await unitOfWork.ShopsRepository.GetByIdAsync(id);
    if (shop == null)
      return false;
   // shop.Distinctive = distinctive;
    if (period != 0)
    {
      shop.DistinctiveExpiryDate = DateTime.Now.AddMonths(period);
    }
    else
    if (shop.DistinctiveExpiryDate!=null)
    {
      shop.DistinctiveExpiryDate = null;
    }
     unitOfWork.ShopsRepository.Update(shop);
     return await unitOfWork.SaveChangesAsync() != 0;
  }

    public async Task<int?> CheckExistsAsync(int id)
    {
      return await unitOfWork.ShopsRepository.IsExistedAsync(id);
    }


/*     public async Task<bool> RemoveAllExpired()
      {

        var shops = unitOfWork.ShopsRepository.GetAllExpired();
    if (shops == null)
      return false;
       unitOfWork.ShopsRepository.RemoveRange(shops);
       return await  unitOfWork.SaveChangesAsync() != 0;
      }*/

}