
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class PCategoriesRepository : 
  GenericRepository<PCategory>,
  IPCategoriesRepository
{
  private readonly MahalakDbContext mahalakDbContext;

  public PCategoriesRepository(MahalakDbContext mahalakDbContext)
    : base(mahalakDbContext)
  {
     this.mahalakDbContext = mahalakDbContext;
  }

  public async Task<List<PCategory>> GetAllBySCategoryIdAsync(int id, CancellationToken ct)
  {
    return await mahalakDbContext.Set<PCategory>().Where(pc => pc.SCategoryId == id).AsNoTracking().ToListAsync(ct);
  }

  public async Task<bool> IsExistedAsync(int id)
  {
    return await mahalakDbContext.Set<PCategory>().AsNoTracking().AnyAsync(p=>p.Id==id);
  } 
}