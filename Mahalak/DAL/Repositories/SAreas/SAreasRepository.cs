
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class SAreasRepository : GenericRepository<SArea>,ISAreasRepository
{
    private readonly MahalakDbContext mahalakDbContext;
    public SAreasRepository(MahalakDbContext mahalakDbContext) : base(mahalakDbContext)
    {
        this.mahalakDbContext=mahalakDbContext;
    }


    public async Task<List<SArea>> GetAllByCityIdAsync(int id, CancellationToken ct)
    {
        return await mahalakDbContext.Set<SArea>()
        .Where(s=>s.CityId==id).AsNoTracking().ToListAsync(ct);
    }

  public async Task<bool> IsExistedAsync(int id)
  {
    return await mahalakDbContext.Set<SArea>().AsNoTracking().AnyAsync(s=>s.Id==id);
  }

}