namespace Mahalak;

public interface IProductImagesManager
{
  Task<List<ProductImageDTO>> GetAllAsync(CancellationToken ct);

  Task<List<ProductImageDTO>> GetAllByProductIdAsync(int? id, CancellationToken ct);

  Task<ProductImageDTO?> GetByIdAsync(int id);

  Task AddCollectionAsync(List<IFormFile> productImages, string userId, CancellationToken ct);

  Task UpdateCollectionAsync(List<IFormFile> newProductImages, int ProductID, string userId, CancellationToken ct);

  Task<bool> DeleteCollectionAsync(int ProductId, CancellationToken ct=default);
}