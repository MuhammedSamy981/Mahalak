namespace Mahalak;
public interface ISCitiesRepository:IGenericRepository<SCity>
{
   List<SCity> GetAllByCountryId(int id);
}