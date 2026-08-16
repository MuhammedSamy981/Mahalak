namespace Mahalak;
public interface IRatingsRepository : IGenericRepository<Rating>
{
  Task<List<Rating>> GetAllWithCommentsInWaitingAsync(CancellationToken ct);

  Task<List<Rating>> GetAllByShopIdAsync(int id, CancellationToken ct);

  Task<Rating?> GetSpecificAsync(string userId, int shopId);

  Task<bool> IsExistedAsync(int id);
}