using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class SCountriesRepository : GenericRepository<SCountry>,ISCountriesRepository
{
  private readonly MahalakDbContext mahalakDbContext;

  public SCountriesRepository(MahalakDbContext mahalakDbContext)
    : base(mahalakDbContext)
  {
     this.mahalakDbContext = mahalakDbContext;
  }

  public async Task<SCountry?> GetByNameAsync(string name)
  {
    return await  mahalakDbContext.Set<SCountry>().FirstOrDefaultAsync(u => u.Name == name);
  }

  public async Task<bool> IsExistedAsync(int id)
  {
    return await mahalakDbContext.Set<SCountry>().AsNoTracking().AnyAsync(s=>s.Id==id);
  }
}