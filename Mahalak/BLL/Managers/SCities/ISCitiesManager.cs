namespace Mahalak;
public interface ISCitiesManager
{
  Task<List<SCityDTO>> GetAllAsync(CancellationToken ct=default);

  Task<List<SCityDTO>> GetAllByCountryIdAsync(int id, CancellationToken ct=default);

  Task<SCityDTO?> GetByIdAsync(int id);

  Task AddAsync(SCityAddDTO cityDTO);

  Task<bool> UpdateAsync(SCityUpdateDTO cityDTO);

  Task<bool> DeleteAsync(int id);

}