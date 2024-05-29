
namespace Mahalak;
public class SCitiesRepository : GenericRepository<SCity>,ISCitiesRepository
{
    private readonly MahalakContext mahalakContext;
    public SCitiesRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
        this.mahalakContext=mahalakContext;
    }

    public List<SCity> GetAllByCountryId(int id)
    {
        return mahalakContext.Set<SCity>()
        .Where(s=>s.CountryID==id).ToList();
    }
}