namespace Mahalak;
public interface IPCategoriesManager
{
  Task<List<PCategoryDTO>> GetAllAsync(CancellationToken ct=default);

  Task<List<PCategoryDTO>> GetAllBySCategoryIdAsync(int id, CancellationToken ct=default);

  Task<PCategoryDTO?> GetByIdAsync(int id);

  Task AddAsync(PCategoryAddDTO categoryDTO);

  Task<bool> UpdateAsync(PCategoryUpdateDTO categoryDTO);

  Task<bool> DeleteAsync(int id);
}