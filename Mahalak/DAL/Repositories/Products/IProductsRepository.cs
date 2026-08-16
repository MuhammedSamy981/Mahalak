namespace Mahalak;
public interface IProductsRepository : IGenericRepository<Product>
{
  Task<List<Product>> GetPaginatedByFiltersAsync(int pageNumber,int pageSize,
    string name,
    int categoryId,
    decimal minPrice,
    decimal maxPrice,
    int conditionId,
    int? countryId, CancellationToken ct);
  Task<int> GetCountByFiltersAsync(string name,int categoryId,decimal minPrice,decimal maxPrice,
    int conditionId,int? countryId, CancellationToken ct);

  Task<List<Product>> GetPaginatedByShopIdAsync(int pageNumber,int pageSize,int id, CancellationToken ct);
  Task<int> GetCountByShopIdAsync(int id, CancellationToken ct);

  Task<List<Product>> GetPaginatedAsync(int pageNumber,int pageSize,string name, CancellationToken ct);
  Task<int> GetCountAsync(string name, CancellationToken ct);

  Task<Product?> GetDetailsByIdAsync(int? id,int? countryId);

  Task<bool> IsExistedAsync(int id);
}

