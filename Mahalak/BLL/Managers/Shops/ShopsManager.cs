namespace Mahalak;
public class ShopsManager : IShopsManager
{
    private readonly IUnitOfWork unitOfWork;

    public ShopsManager(IUnitOfWork unitOfWork)
    {
      this.unitOfWork=unitOfWork;
    }

    public List<GetAllPaginatedShopsDTO> GetAllPaginated(int pageSize,int pageNumber)
    {
        var shops=unitOfWork.ShopsRepository.GetAll();

                  int listEnd=pageSize*pageNumber;
      int listStart=listEnd-pageSize;
      if(pageSize>shops.Count-listStart)
      {
        pageSize=shops.Count-listStart;
      }
        return shops.Select(s=>new GetAllPaginatedShopsDTO
        {
            ID=s.ID,
            Name=s.Name,
            CategoryID=s.CategoryID,
            CountryID=s.CountryID,
            CityID=s.CityID,
            AreaID=s.AreaID,
            Status=s.Status,
            Distinctive=s.Distinctive,
            ExpDtOfMark=s.ExpDtOfMark,
            MaxProductNum=s.MaxProductNum,
            CreatingDate=s.CreatingDate,
            ShopsCount=shops.Count,
            UserID=s.UserID
        }).ToList().GetRange(listStart,pageSize);
    } 

    public List<GetAllPaginatedShopsWithFilterDTO> GetAllPaginatedWithFilter(int pageSize,
    int pageNumber,int categoryID, int countryID, int cityID, int areaID)
    {
        var shops= unitOfWork.ShopsRepository.GetAllWithFilters(categoryID,countryID,cityID,areaID);
      int listEnd=pageSize*pageNumber;
      int listStart=listEnd-pageSize;
      if(pageSize>shops.Count-listStart)
      {
        pageSize=shops.Count-listStart;
      }
    
        return shops.Select( s=>new GetAllPaginatedShopsWithFilterDTO
        {
            ID=s.ID,
            Name=s.Name,
            CategoryID=s.CategoryID,
            CountryID=s.CountryID,
            CityID=s.CityID,
            AreaID=s.AreaID,
            Status=s.Status,
            TotalRaters=s.Ratings.Count,
            Distinctive=s.Distinctive,
            ExpDtOfMark=s.ExpDtOfMark,
            MaxProductNum=s.MaxProductNum,
            CreatingDate=s.CreatingDate,
            ShopsCount=shops.Count,
            UserID=s.UserID
        }).ToList().GetRange(listStart,pageSize);
    }

    public List<GetAllPaginatedShopsByUserIdDTO> GetAllPaginatedByUserId(Guid id, int pageSize, int pageNumber)
    {
        var shops=unitOfWork.ShopsRepository.GetAllByUserId(id);
                      int listEnd=pageSize*pageNumber;
      int listStart=listEnd-pageSize;
      if(pageSize>shops.Count-listStart)
      {
        pageSize=shops.Count-listStart;
      }
        return shops.Select(s=>new GetAllPaginatedShopsByUserIdDTO
        {
            ID=s.ID,
            Name=s.Name,
            CategoryID=s.CategoryID,
            CountryID=s.CountryID,
            CityID=s.CityID,
            AreaID=s.AreaID,
            Status=s.Status,
            Distinctive=s.Distinctive,
            ExpDtOfMark=s.ExpDtOfMark,
            MaxProductNum=s.MaxProductNum,
            CreatingDate=s.CreatingDate,
            ShopsCount=shops.Count,
            UserID=s.UserID
        }).ToList().GetRange(listStart,pageSize);
    }

    public List<GetAllPaginatedShopsByNameDTO> GetAllPaginatedByName(string name,int pageSize,int pageNumber)
    {
        var shops=unitOfWork.ShopsRepository.GetAllByName(name);
                         int listEnd=pageSize*pageNumber;
      int listStart=listEnd-pageSize;
      if(pageSize>shops.Count-listStart)
      {
        pageSize=shops.Count-listStart;
      }
        return shops.Select(s=>new GetAllPaginatedShopsByNameDTO
        {
            ID=s.ID,
            Name=s.Name,
            CategoryID=s.CategoryID,
            CountryID=s.CountryID,
            CityID=s.CityID,
            AreaID=s.AreaID,
            Status=s.Status,
            Distinctive=s.Distinctive,
            ExpDtOfMark=s.ExpDtOfMark,
            MaxProductNum=s.MaxProductNum,
            CreatingDate=s.CreatingDate,
            ShopsCount=shops.Count,
            UserID=s.UserID
        }).ToList().GetRange(listStart,pageSize);
    }

    public GetShopByIdDTO? GetById(int? id)
    {
        var shop=unitOfWork.ShopsRepository.GetById(id);
        if(shop==null)
        {
            return null;
        }
        
        return new GetShopByIdDTO
        {
            ID=shop.ID,
            Name=shop.Name,
            CategoryID=shop.CategoryID,
            CountryID=shop.CountryID,
            CityID=shop.CityID,
            AreaID=shop.AreaID,
            Status=shop.Status,
            Distinctive=shop.Distinctive,
            ExpDtOfMark=shop.ExpDtOfMark,
            MaxProductNum=shop.MaxProductNum,
            CreatingDate=shop.CreatingDate,
            ProductsCount=unitOfWork.ProductsRepository.GetAllByShopId(id!.Value).Count,
            UserID=shop.UserID
        };
    }

    public GetShopDetailsByIdDTO? GetAllDetailsById(int? id)
    {
        var shop=unitOfWork.ShopsRepository.GetAllDetailsById(id);
        if(shop==null)
        {
            return null;
        }
        return new GetShopDetailsByIdDTO
        {
            ID=shop.ID,
            Name=shop.Name,
            User=new GetUserByIdDTO
            {
                ID=shop.UserID,
                Name=shop.User?.Name!,
                Email=shop.User?.Email!,
                Phone=shop.User?.Phone!
            },
            ClientsRatings=shop.Ratings.Select(r=>new GetAllRatingsDTO
            {
                ID=r.ID,
                UserName=r.User!.Name,
                Value=r.Value,
                Comment=r.Comment,
                Status=r.Status,
                Datetime=r.Datetime,
                ShopID=r.ShopID,
                UserID=r.UserID
            }).ToList(),
            Country=new GetSCountryByIdDTO
            {
                ID=shop.CountryID,
                Name=shop.Country?.Name!
            },
            City=new GetSCityByIdDTO
            {
                ID=shop.CityID,
                Name=shop.City?.Name!
            },
            Area=new GetSAreaByIdDTO
            {
                ID=shop.AreaID,
                Name=shop.Area?.Name!
            },
            Products=shop.Products.Select(p=>new GetAllProductsDTO
            {
                ID=p.ID,
                Name=p.Name,
                InterfaceImage=p.Images.Select(img=>new GetProductImageByIdDTO
                {
                    ID=img.ID,
                    Name=img.Name,
                    ProductID=img.ProductID
                }).ToList().FirstOrDefault()
            }).ToList()
        };
    }

    public void Add(AddShopDTO shopDTO)
    {
        Shop shop=new Shop
        {
            Name=shopDTO.Name,
            CategoryID=shopDTO.CategoryID,
            CountryID=shopDTO.CountryID,
            CityID=shopDTO.CityID,
            AreaID=shopDTO.AreaID,
            CreatingDate=DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt"),
            UserID=shopDTO.UserID
        };

        unitOfWork.ShopsRepository.Add(shop);
        unitOfWork.SaveChanges();
    }

    public bool Update(UpdateShopDTO shopDTO)
    {
        var shop=unitOfWork.ShopsRepository.GetById(shopDTO.ID);
        if(shop==null)
        {
            return false;
        }
        shop.Name=shopDTO.Name;
        shop.CategoryID=shopDTO.CategoryID;
        shop.Status=string.Empty;
        unitOfWork.ShopsRepository.Update(shop);
        unitOfWork.SaveChanges();
        return true;

    }

    public bool Delete(int id)
    {
        var shop=unitOfWork.ShopsRepository.GetById(id);
        if(shop==null)
        {
            return false;
        }

        unitOfWork.ShopsRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return true;
    }

    public bool VerifyField(string value)
    {
        var shops = unitOfWork.ShopsRepository.GetAll();

        for (int i = 0; i < shops.Count; i++)
        {
                if (shops[i].Name == value.Trim())
                {
                    return false;
                }

        }
        return true;
    }

    public bool VerifyEditField(string value, int? id)
    {
        Console.WriteLine(id);
        var shops = unitOfWork.ShopsRepository.GetAll();
        var shopToEdit = unitOfWork.ShopsRepository.GetById(id);
        if (shopToEdit != null)
        {
            for (int i = 0; i < shops.Count; i++)
            {
                if (shopToEdit.Name != value.Trim())
                {
                    if (shops[i].Name == value)
                    {
                        return false;
                    }

                }
            }
        }
        return true;
    }

    public bool VerifyField(int value)
    {
        if(value==0)
        {
            return false;
        }

        return true;
    }

    public void EditStatus(int id, string status)
    {
        var shop = unitOfWork.ShopsRepository.GetById(id);
        if (shop != null)
        {
            shop.Status = status;
            unitOfWork.ShopsRepository.Update(shop);
            unitOfWork.SaveChanges();
        }

    }

    public async Task EditDistinctive(int id, bool distinctive, int period)
    {
        var shop = unitOfWork.ShopsRepository.GetById(id);
        if (shop != null)
        {
            shop.Distinctive = distinctive;
            if(period!=0)
            {
            shop.ExpDtOfMark=DateTime.Now.
            AddMonths(period).ToString("dddd, dd MMMM yyyy h:mm tt");
            }
            else
            {
             shop.ExpDtOfMark=string.Empty;
            }
            unitOfWork.ShopsRepository.Update(shop);
            await unitOfWork.SaveChangesAsync();
        }

    }

    public async Task<bool> CheckDistinctivePeriod()
    {
            
      foreach(var shop in unitOfWork.ShopsRepository.GetAll())
      {
        if(shop.ExpDtOfMark!=string.Empty){
      if(Convert.ToDateTime(shop.ExpDtOfMark) <= DateTime.Now)
      { 
        await EditDistinctive(shop.ID,false,0);
        }}
      }
      return true;
    }


}