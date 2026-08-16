namespace Mahalak;
public interface ISAreasRepository : IGenericRepository<SArea>
{
  Task<List<SArea>> GetAllByCityIdAsync(int id, CancellationToken ct);
  Task<bool> IsExistedAsync(int id);
}