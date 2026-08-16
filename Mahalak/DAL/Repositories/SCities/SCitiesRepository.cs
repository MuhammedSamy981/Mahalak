
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class SCitiesRepository : GenericRepository<SCity>,ISCitiesRepository
{
  private readonly MahalakDbContext mahalakDbContext;

  public SCitiesRepository(MahalakDbContext mahalakDbContext)
    : base(mahalakDbContext)
  {
     this.mahalakDbContext = mahalakDbContext;
  }

  public async Task<List<SCity>> GetAllByCountryIdAsync(int id, CancellationToken ct)
  {
    return await  mahalakDbContext.Set<SCity>().Where(s => s.CountryId == id).AsNoTracking().ToListAsync(ct);
  }

  public async Task<bool> IsExistedAsync(int id)
  {
    return await mahalakDbContext.Set<SCity>().AsNoTracking().AnyAsync(s=>s.Id==id);
  }
}