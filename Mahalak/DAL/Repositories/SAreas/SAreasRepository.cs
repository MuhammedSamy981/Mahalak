namespace Mahalak;
public class SAreasRepository : GenericRepository<SArea>,ISAreasRepository
{
    private readonly MahalakContext mahalakContext;
    public SAreasRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
        this.mahalakContext=mahalakContext;
    }

    public List<SArea> GetAllByCityId(int id)
    {
        return mahalakContext.Set<SArea>()
        .Where(s=>s.CityID==id).ToList();
    }
}