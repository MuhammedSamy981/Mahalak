namespace Mahalak;
public interface ISCategoriesManager
{
  Task<List<SCategoryDTO>> GetAllAsync(CancellationToken ct=default);

  Task<SCategoryDTO?> GetByIdAsync(int id);

  Task AddAsync(SCategoryAddDTO categoryDTO);

  Task<bool> UpdateAsync(SCategoryUpdateDTO categoryDTO);

  Task<bool> DeleteAsync(int id);

}