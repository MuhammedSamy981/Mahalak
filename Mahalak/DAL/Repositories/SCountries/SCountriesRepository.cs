namespace Mahalak;
public class SCountriesRepository : GenericRepository<SCountry>,ISCountriesRepository
{
    public SCountriesRepository(MahalakContext mahalakContext) : base(mahalakContext)
    {
         
    }
}