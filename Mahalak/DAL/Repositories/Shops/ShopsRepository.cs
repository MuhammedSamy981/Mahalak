
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class ShopsRepository : GenericRepository<Shop>,IShopsRepository
{
  private readonly MahalakDbContext mahalakDbContext;

  public ShopsRepository(MahalakDbContext mahalakDbContext)
    : base(mahalakDbContext)
  {
     this.mahalakDbContext = mahalakDbContext;
  }

  public async Task<List<Shop>> GetPaginatedByFiltersAsync(int pageNumber,int pageSize, int categoryId,
    int countryId,
    int cityId,
    int areaId, CancellationToken ct)
    {
        return await GetAllByFilters(categoryId,countryId,cityId,areaId).Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
    }
    
  public async Task<int> GetCountByFiltersAsync( int categoryId,
    int countryId,
    int cityId,
    int areaId, CancellationToken ct)
    {
      return await GetAllByFilters(categoryId,countryId,cityId,areaId).CountAsync(ct);
    }

  private IQueryable<Shop> GetAllByFilters(
    int categoryId,
    int countryId,
    int cityId,
    int areaId)
  {
    IQueryable<Shop> source= mahalakDbContext.Set<Shop>().AsNoTracking().Where (s => s.Status == "مقبول");

    if (categoryId != 0)
    {
      source=source.Where(s => s.CategoryId == categoryId);
    }
    if (countryId != 0)
    {
      source=source.Where(s => s.CountryId == countryId);
    }
    if (cityId != 0)
    {
      source=source.Where(s => s.CityId == cityId);
    }
    if (areaId != 0)
    {
      source=source.Where(s => s.AreaId == areaId);
    }

    return source.Include (s => s.Ratings).OrderByDescending(s => s.DistinctiveExpiryDate).ThenByDescending(s => s.Ratings.Select(r => r.Value)
    .Average());
  }


  public async Task<List<Shop>> GetPaginatedByUserIdAsync(int pageNumber,int pageSize,string id, CancellationToken ct)
  {
    return await GetAllByUserId(id).Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
  }
    
  public async Task<int> GetCountByUserIdAsync(string id, CancellationToken ct)
  {
    return await GetAllByUserId(id).CountAsync(ct);
  }

  private IQueryable<Shop> GetAllByUserId(string id)
  {
    return mahalakDbContext.Set<Shop>().AsNoTracking().Where(s => s.UserId == id)
    .OrderByDescending(s => s.Id);
  }


  public async Task<List<Shop>> GetPaginatedByNameAsync(int pageNumber,int pageSize,string name, CancellationToken ct)
  {
      return await GetAllByName(name).Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
  }
    
  public async Task<int> GetCountByNameAsync(string name, CancellationToken ct)
  {
      return await GetAllByName(name).CountAsync(ct);
  }

  private IQueryable<Shop> GetAllByName(string name)
  {
    return mahalakDbContext.Set<Shop>().AsNoTracking().Where (s => s.Name.Contains(name))
    .OrderByDescending(s => s.Id);
  }

  public async Task<Shop?> GetDetailsByIdAsync(int? id,int? countryId)
  {
    return await mahalakDbContext.Set<Shop>().AsNoTracking().Include(s => s.Category).Include(s => s.User)
    .Include(s => s.Country).Include(s => s.City).Include(s => s.Area)
    .Include(s => s.Products.Where(p => p.Status == "مقبول"))
    .ThenInclude(p => p.Images).FirstOrDefaultAsync (s =>s.Id == id && s.CountryId == countryId);
  }

   public async Task<int?> IsExistedAsync(int id)
  {
    var shop= await mahalakDbContext.Set<Shop>().Include(s => s.Products).AsNoTracking().Select(s=>new{s.Products.Count,s.Id}).FirstOrDefaultAsync(s=>s.Id==id);
    return shop!=null? shop.Count:null;
  }

/* public IQueryable<Shop> GetAllExpired()
  {
return mahalakDbContext.Shops.Include(s=>s.User)
.Where(s=>s.User!.MaxShopNum>2 && s.User.AddedShopsExpiryDate>=DateTime.Now);

  }

 */   
}