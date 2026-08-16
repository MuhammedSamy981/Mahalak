using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class ProductImagesRepository : GenericRepository<ProductImage>,IProductImagesRepository
{
  private readonly MahalakDbContext mahalakDbContext;

  public ProductImagesRepository(MahalakDbContext mahalakDbContext)
    : base(mahalakDbContext)
  {
     this.mahalakDbContext = mahalakDbContext;
  }

  public async Task<List<ProductImage>> GetAllByProductIdAsync(int? id, CancellationToken ct)
  {
    return await mahalakDbContext.Set<ProductImage>().Where(p => p.ProductId == id).AsNoTracking().ToListAsync(ct);
  }

/*public async Task<bool> IsExistedAsync(int id)
  {
    return await mahalakDbContext.Set<ProductImage>().AsNoTracking().AnyAsync(p=>p.Id==id);
  }*/
}
