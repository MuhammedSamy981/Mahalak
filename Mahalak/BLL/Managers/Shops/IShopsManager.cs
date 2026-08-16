namespace Mahalak;
public interface IShopsManager
{
Task<List<ShopSummaryDTO>> GetPaginatedAsync(int pageNumber,int pageSize, CancellationToken ct=default);
Task<int> GetCountAsync(CancellationToken ct=default);
Task<List<ShopDTO>> GetPaginatedByFiltersAsync(int pageNumber,int pageSize,
    int categoryId=0,
    int countryId=0,
    int cityId=0,
    int areaId=0, CancellationToken ct=default);

Task<int> GetCountByFiltersAsync(int categoryId=0,
    int countryId=0,
    int cityId=0,
    int areaId=0, CancellationToken ct=default);

  Task<List<ShopSummaryDTO>> GetPaginatedByUserIdAsync(
    int pageNumber,int pageSize,string id, CancellationToken ct=default);

  Task<int> GetCountByUserIdAsync(string id, CancellationToken ct=default);

 Task<List<ShopSummaryDTO>> GetPaginatedByNameAsync(
    int pageNumber,int pageSize,string name, CancellationToken ct=default);
  Task<int> GetCountByNameAsync(string name, CancellationToken ct=default);
  
  Task<ShopDetailsSummaryDTO?> GetByIdAsync(int? id, CancellationToken ct=default);

  Task<ShopDetailsDTO?> GetDetailsByIdAsync(int? id,int? countryId);

  Task<bool> AddAsync(ShopAddDTO shopDTO);

  Task<bool> UpdateAsync(ShopUpdateDTO shopDTO);

  Task<bool> DeleteAsync(int id);

  Task<bool> VerifyFieldAsync(string value, CancellationToken ct=default);

  Task<bool> VerifyEditFieldAsync(string value, int? id, CancellationToken ct=default);

  bool VerifyField(int value);

  Task<bool> EditStatusAsync(int id, string status);

  Task<bool> EditDistinctiveAsync(int id,int period);

  Task<int?> CheckExistsAsync(int id);

 //Task<bool> RemoveAllExpired();
}
