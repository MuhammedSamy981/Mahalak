namespace Mahalak;
public interface IShopsRepository : IGenericRepository<Shop>
{
  Task<List<Shop>> GetPaginatedByFiltersAsync(int pageNumber,int pageSize, int categoryId,
    int countryId,
    int cityId,
    int areaId, CancellationToken ct);

Task<int> GetCountByFiltersAsync( int categoryId,
    int countryId,
    int cityId,
    int areaId, CancellationToken ct);

 Task<List<Shop>> GetPaginatedByUserIdAsync(int pageNumber,int pageSize,string id, CancellationToken ct);
Task<int> GetCountByUserIdAsync(string id, CancellationToken ct);

  Task<List<Shop>> GetPaginatedByNameAsync(int pageNumber,int pageSize,string name, CancellationToken ct);
Task<int> GetCountByNameAsync(string name, CancellationToken ct);

  Task<Shop?> GetDetailsByIdAsync(int? id,int? countryId);

  Task<int?> IsExistedAsync(int id); 

  // IQueryable<Shop> GetAllExpired();
}





