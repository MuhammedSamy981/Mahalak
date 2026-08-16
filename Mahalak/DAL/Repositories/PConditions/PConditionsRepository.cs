using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class PConditionsRepository : GenericRepository<PCondition>,IPConditionsRepository
{
    private readonly MahalakDbContext mahalakDbContext;


    public PConditionsRepository(MahalakDbContext mahalakDbContext) : base(mahalakDbContext)
    {
      this.mahalakDbContext=mahalakDbContext;
    }

    public async Task<bool> IsExistedAsync(int id)
    {
      return await mahalakDbContext.Set<SCategory>().AsNoTracking().AnyAsync(s=>s.Id==id);
    }
}