using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class ProductImagesRepository : GenericRepository<ProductImage>,IProductImagesRepository
{
    private readonly MahalakContext mahalakContext;
    public ProductImagesRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
        
        this.mahalakContext=mahalakContext;
    }

    public List<ProductImage> GetAllByProductId(int? id)
    {
        return mahalakContext.Set<ProductImage>().Where(p=>p.ProductID==id).ToList();
    }
}