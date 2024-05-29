namespace Mahalak;
public interface IProductsRepository:IGenericRepository<Product>
{
    List<Product> GetAllByShopId(int id);
     List<Product> GetAllByName(string name);

    Product? GetAllDetailsById(int? id);
}