namespace Mahalak;
public interface ISCountriesRepository : IGenericRepository<SCountry>
{
  Task<SCountry?> GetByNameAsync(string name);
  Task<bool> IsExistedAsync(int id);
}