using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class SCategoriesRepository : GenericRepository<SCategory>,ISCategoriesRepository
{
    private readonly MahalakDbContext mahalakDbContext;


    public SCategoriesRepository(MahalakDbContext mahalakDbContext) : base(mahalakDbContext)
    {
        this.mahalakDbContext=mahalakDbContext;
    }
    public async Task<bool> IsExistedAsync(int id)
    {
       return await mahalakDbContext.Set<SCategory>().AsNoTracking().AnyAsync(s=>s.Id==id);
    }
}