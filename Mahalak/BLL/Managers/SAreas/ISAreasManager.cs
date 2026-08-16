namespace Mahalak;
public interface ISAreasManager
{
  Task<List<SAreaDTO>> GetAllAsync(CancellationToken ct=default);

  Task<List<SAreaDTO>> GetAllByCityIdAsync(int id, CancellationToken ct=default);

  Task<SAreaDTO?> GetByIdAsync(int id);

  Task AddAsync(SAreaAddDTO areaDTO);

  Task<bool> UpdateAsync(SAreaUpdateDTO areaDTO);

  Task<bool> DeleteAsync(int id);

}