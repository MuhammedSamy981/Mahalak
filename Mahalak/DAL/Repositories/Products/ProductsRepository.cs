
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class ProductsRepository : 
  GenericRepository<Product>,
  IProductsRepository
{
  private readonly MahalakDbContext mahalakDbContext;

  public ProductsRepository(MahalakDbContext mahalakDbContext)
    : base(mahalakDbContext)
  {
     this.mahalakDbContext = mahalakDbContext;
  }


  public async Task<List<Product>> GetPaginatedByFiltersAsync(int pageNumber,int pageSize,
    string name,
    int categoryId,
    decimal minPrice,
    decimal maxPrice,
    int conditionId,
    int? countryId, CancellationToken ct)
  {
    IQueryable<Product> source = GetAllByFilters(name,categoryId,minPrice,maxPrice,conditionId,countryId);
    return await source.Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
  }

      public async Task<int> GetCountByFiltersAsync(
    string name,
    int categoryId,
    decimal minPrice,
    decimal maxPrice,
    int conditionId,
    int? countryId
    , CancellationToken ct)
    {
      IQueryable<Product> source = GetAllByFilters(name,categoryId,minPrice,maxPrice,conditionId,countryId);
      return await source.CountAsync(ct);
    }

  private IQueryable<Product> GetAllByFilters(
    string name,
    int categoryId,
    decimal minPrice,
    decimal maxPrice,
    int conditionId
    ,int? countryId)
  {
    IQueryable<Product> source = mahalakDbContext.Set<Product>().AsNoTracking().Include(p=>p.Shop).ThenInclude(s => s!.Country)
    .Where(p => p.Status == "مقبول" && p.Shop!.CountryId==countryId);

        if (name != null && name!=string.Empty)
    {
      source=source.Where(p => p.Name.Contains(name)); 
    }

    if (categoryId != 0)
    {
      source=source.Where(p => p.CategoryId == categoryId);
    }


      if (minPrice != 0)
      {
         source=source.Where(p => p.Price>=minPrice);
      }

      if (maxPrice != 0)
      {
         source=source.Where(p => p.Price<=maxPrice);
      }
      
        if (conditionId != 0)
    {
source=source.Where(p => p.ConditionId==conditionId);
    }

    return source.Include(p => p.Images).Include(p => p.Category).Include(p => p.Condition)
    .OrderByDescending(p => p.Shop!.DistinctiveExpiryDate).ThenByDescending(p => p.AddingDate);
  }


  public async Task<List<Product>> GetPaginatedByShopIdAsync(int pageNumber,int pageSize,int id, CancellationToken ct)
  {
    return await GetAllByShopId(id).Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
  }

    public async Task<int> GetCountByShopIdAsync(int id, CancellationToken ct)
    {
      return await GetAllByShopId(id).CountAsync(ct);
    }

  private IQueryable<Product> GetAllByShopId(int id)
  {
    return mahalakDbContext.Set<Product>().AsNoTracking().Where (p => p.ShopId==id).Include(p => p.Shop)
    .OrderByDescending(p => p.Id);
  }


  public async Task<List<Product>> GetPaginatedAsync(int pageNumber,int pageSize,string name, CancellationToken ct)
  {
    return await GetAll(name).Skip((pageNumber - 1) * pageSize)
        .Take(pageSize).ToListAsync(ct);
  }

    public async Task<int> GetCountAsync(string name, CancellationToken ct)
    {
      return await GetAll(name).CountAsync(ct);
    }

  private IQueryable<Product> GetAll(string name)
  {
    return mahalakDbContext.Set<Product>().AsNoTracking().Include(p => p.Shop).Where (p => p.Name.Contains(name) && p.Shop!.Status == "مقبول")
    .OrderByDescending(p => p.Id);
  }


  public async Task<Product?> GetDetailsByIdAsync(int? id,int? countryId)
  {
    return await mahalakDbContext.Set<Product>().AsNoTracking().Include(p => p.Shop).ThenInclude(s => s!.Country).Include(p => p.Category)
    .Include(p => p.Condition).Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == id && p.Shop!.CountryId==countryId);
  }

  public async Task<bool> IsExistedAsync(int id)
  {
    return await mahalakDbContext.Set<Product>().AsNoTracking().AnyAsync(p=>p.Id==id);
  }  
}