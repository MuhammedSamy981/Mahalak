namespace Mahalak;
public interface IPCategoriesRepository : IGenericRepository<PCategory>
{
  Task<List<PCategory>> GetAllBySCategoryIdAsync(int id, CancellationToken ct);
  Task<bool> IsExistedAsync(int id);
}