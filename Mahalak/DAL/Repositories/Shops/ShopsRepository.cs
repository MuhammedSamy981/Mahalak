
using Microsoft.EntityFrameworkCore;

namespace Mahalak;
public class ShopsRepository : GenericRepository<Shop>,IShopsRepository
{
    private readonly MahalakContext mahalakContext;
    public ShopsRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
        
        this.mahalakContext=mahalakContext;
    }

public List<Shop> GetAllWithFilters(int categoryID,int countryID, int cityID, int areaID)
    {  
        var shops=(categoryID == 0 && countryID == 0) ?  mahalakContext.Set<Shop>().Include(s=>s.Ratings) :
                (countryID == 0 && categoryID != 0) ?  mahalakContext.Set<Shop>().Include(s=>s.Ratings).Where(s=>s.CategoryID==categoryID) :
                (cityID == 0 && countryID != 0 && categoryID == 0) ?  mahalakContext.Set<Shop>().Include(s=>s.Ratings).Where(s=>s.CountryID==countryID):
                (cityID == 0 && countryID != 0 && categoryID != 0) ?  mahalakContext.Set<Shop>().Include(s=>s.Ratings).Where(s=>s.CategoryID==categoryID&&s.CountryID==countryID):
                (areaID == 0 && cityID != 0 && countryID != 0 && categoryID == 0) ?  mahalakContext.Set<Shop>().Include(s=>s.Ratings).Where(s=>s.CountryID==countryID&&s.CityID==cityID) :
                (areaID == 0 && cityID != 0 && countryID != 0 && categoryID != 0) ?  mahalakContext.Set<Shop>().Include(s=>s.Ratings).Where(s=>s.CategoryID==categoryID&&s.CountryID==countryID&&s.CityID==cityID) :
                mahalakContext.Set<Shop>().Include(s=>s.Ratings).Where(s=>s.CategoryID==categoryID&&s.CountryID==countryID&&s.CityID==cityID&&s.AreaID==areaID);

        return shops.Where(s=>s.Status=="مقبول").ToList();        

    }
    public List<Shop> GetAllByUserId(Guid id)
    {
      var shops=mahalakContext.Set<Shop>()
        .Where(s=>s.UserID==id).OrderByDescending(s=>s.ID).ToList();
         return shops;
    }

    public List<Shop> GetAllByName(string name)
    {
      var shops=mahalakContext.Set<Shop>()
        .Where(s=>s.Name.Contains(name)).OrderByDescending(s=>s.ID).ToList();
         return shops;
    }
   public Shop? GetAllDetailsById(int? id)
    {
        return mahalakContext.Set<Shop>().Include(s=>s.User).Include(s=>s.Ratings).ThenInclude(r=>r.User)
        .Include(s=>s.Country).Include(s=>s.City).Include(s=>s.Area)
        .Include(s=>s.Products.Where(p=>p.Status=="مقبول")).ThenInclude(p=>p.Images)
        .FirstOrDefault(s=>s.ID==id);
    }

    
    
}