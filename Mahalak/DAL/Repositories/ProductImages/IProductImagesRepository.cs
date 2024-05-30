namespace Mahalak;
public interface IProductImagesRepository:IGenericRepository<ProductImage>
{
    List<ProductImage> GetAllByProductId(int? id);
}