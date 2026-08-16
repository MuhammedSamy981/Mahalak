namespace Mahalak;
public interface IProductsManager
{
Task<List<ProductSummaryDTO>> GetPaginatedAsync(
    int pageNumber,int pageSize, CancellationToken ct=default,string name="");
Task<int> GetCountAsync(string name="",CancellationToken ct=default);
Task<List<ProductDTO>> GetPaginatedByFiltersAsync(
    int pageNumber,int pageSize,int? countryId, CancellationToken ct=default,
    string name="",
    int categoryId=0,
    decimal minPrice=0,
    decimal maxPrice=0,
    int conditionId=0);

Task<int> GetCountByFiltersAsync(int? countryId,CancellationToken ct=default,string name="",
    int categoryId=0,
    decimal minPrice=0,
    decimal maxPrice=0,
    int conditionId=0);

Task<List<ProductSummaryDTO>> GetPaginatedByShopIdAsync(
    int pageNumber,int pageSize,int id, CancellationToken ct=default);
    Task<int> GetCountByShopIdAsync(int id, CancellationToken ct=default);

  Task<ProductDetailsSummaryDTO?> GetDetailsSummaryByIdAsync(int? id,int? countryId);

  Task<ProductDetailsDTO?> GetDetailsByIdAsync(int? id,int? countryId);

  Task<bool> AddAsync(ProductAddDTO productDTO);

  Task<bool> UpdateAsync(ProductUpdateDTO productDTO);

  Task<bool> DeleteAsync(int id);

  bool VerifyField(int value);

  Task<bool> EditStatusAsync(int id, string status);
}
