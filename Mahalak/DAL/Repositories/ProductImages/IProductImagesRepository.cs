namespace Mahalak;
public interface IProductImagesRepository : IGenericRepository<ProductImage>
{
  Task<List<ProductImage>> GetAllByProductIdAsync(int? id, CancellationToken ct);
  //Task<bool> IsExistedAsync(int id);
}