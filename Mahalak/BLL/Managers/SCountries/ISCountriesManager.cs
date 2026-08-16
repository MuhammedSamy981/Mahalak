namespace Mahalak;
public interface ISCountriesManager
{
  Task<List<SCountryDTO>> GetAllAsync(CancellationToken ct=default);

  Task<SCountryDTO?> GetByIdAsync(int id);

  Task<int?> GetIdByNameAsync(string name);

  Task AddAsync(SCountryAddDTO countryDTO);

  Task<bool> UpdateAsync(SCountryUpdateDTO countryDTO);

  Task<bool> DeleteAsync(int id);
}