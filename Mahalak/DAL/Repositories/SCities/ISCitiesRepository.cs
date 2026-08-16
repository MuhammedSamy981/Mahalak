namespace Mahalak;
public interface ISCitiesRepository : IGenericRepository<SCity>
{
  Task<List<SCity>> GetAllByCountryIdAsync(int id, CancellationToken ct);
  Task<bool> IsExistedAsync(int id);
}