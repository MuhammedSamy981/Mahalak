
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class ProductsRepository : GenericRepository<Product>,IProductsRepository
{
    private readonly MahalakContext mahalakContext;
    public ProductsRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
        this.mahalakContext=mahalakContext;
    }

    public List<Product> GetAllByShopId(int id)
    {
         return mahalakContext.Set<Product>().Where(p=>p.ShopID==id).OrderByDescending(p=>p.ID).ToList();
    }
    public List<Product> GetAllByName(string name)
    {
      var products=mahalakContext.Set<Product>()
        .Where(p=>p.Name.Contains(name)).OrderByDescending(p=>p.ID).ToList();
         return products;
    }

    public Product? GetAllDetailsById(int? id)
    {
         return mahalakContext.Set<Product>().Include(p=>p.Category).Include(p=>p.Condition)
        .Include(p=>p.Images).FirstOrDefault(p=>p.ID==id);
    }
}