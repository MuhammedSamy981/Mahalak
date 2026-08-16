
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class RatingsRepository : GenericRepository<Rating>,IRatingsRepository
{
    private readonly MahalakDbContext mahalakDbContext;
    public RatingsRepository(MahalakDbContext mahalakDbContext) : base(mahalakDbContext)
    {
        this.mahalakDbContext=mahalakDbContext;
    }

    public async Task<List<Rating>> GetAllWithCommentsInWaitingAsync(CancellationToken ct)
    {

        return await mahalakDbContext.Set<Rating>().Include(r=>r.User).Where(r=>r.Status==string.Empty)
        .AsNoTracking().ToListAsync(ct);
    }

    public async Task<List<Rating>> GetAllByShopIdAsync(int id, CancellationToken ct)
    {
        return await mahalakDbContext.Set<Rating>().Include(r=>r.User).Where(r=>r.ShopId==id).AsNoTracking().ToListAsync(ct);
    }
    
    public async Task<Rating?> GetSpecificAsync(string userId, int shopId)
    {
        return await mahalakDbContext.Set<Rating>().FirstOrDefaultAsync(r => r.UserId == userId && r.ShopId == shopId);
    }

    public async Task<bool> IsExistedAsync(int id)
    {
       return await mahalakDbContext.Set<Rating>().AsNoTracking().AnyAsync(r=>r.Id==id);
    }

/*    public bool CheckExistence(string userId, int shopId)
    {
        var rating = mahalakDbContext.Set<Rating>().FirstOrDefault(r => r.UserID == userId && r.ShopID == shopId);
        if (rating != null)
        {
            return false;
        }
        return true;
    }*/


}