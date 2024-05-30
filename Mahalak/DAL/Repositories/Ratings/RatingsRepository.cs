
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class RatingsRepository : GenericRepository<Rating>,IRatingsRepository
{
    private readonly MahalakContext mahalakContext;
    public RatingsRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
        this.mahalakContext=mahalakContext;
    }

    public async Task<List<Rating>> GetAllWithCommentsInWaiting()
    {

        return await mahalakContext.Set<Rating>().Include(r=>r.User).Where(r=>r.Status==string.Empty).ToListAsync();
    }

    public async Task<List<Rating>> GetAllByShopID(int id)
    {

        return await mahalakContext.Set<Rating>().Where(r=>r.ShopID==id).ToListAsync();
    }

    public bool CheckExistence(Guid userId,int shopId)
    {
        var rating=mahalakContext.Set<Rating>().FirstOrDefault(r=>r.UserID==userId&&r.ShopID==shopId);
        if(rating!=null)
        {
            return false;
        }
        return true;
    }  
}