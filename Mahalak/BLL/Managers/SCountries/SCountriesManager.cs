namespace Mahalak;
public class SCountriesManager : ISCountriesManager
{
  private readonly IUnitOfWork unitOfWork;

  public SCountriesManager(IUnitOfWork unitOfWork) =>  this.unitOfWork = unitOfWork;

  public async Task<List<SCountryDTO>> GetAllAsync(CancellationToken ct=default)
  {
    var countries=await  unitOfWork.SCountriesRepository.GetAllAsync(ct);
    return countries.Select(c => new SCountryDTO
    {
      Id = c.Id,
      Name = c.Name,
      Currency = c.Currency
    }).ToList();
  }

  public async Task<SCountryDTO?> GetByIdAsync(int id)
  {
    var country = await  unitOfWork.SCountriesRepository.GetByIdAsync(id);
    if (country == null)
      return null;
    return new SCountryDTO()
    {
      Id = country.Id,
      Name = country.Name,
      Currency = country.Currency
    };
  }

  public async Task<int?> GetIdByNameAsync(string name)
  {
    var country = await  unitOfWork.SCountriesRepository.GetByNameAsync(name.Trim());
    return country == null ? null:country.Id;
  }

  public async Task AddAsync(SCountryAddDTO countryDTO)
  {
    unitOfWork.SCountriesRepository.Add(new SCountry()
    {
      Id = countryDTO.Id,
      Name = countryDTO.Name.Trim(),
      Currency = countryDTO.Currency
    });
    await unitOfWork.SaveChangesAsync();
  }

  public async Task<bool> UpdateAsync(SCountryUpdateDTO countryDTO)
  {
    var country = await  unitOfWork.SCountriesRepository.GetByIdAsync(countryDTO.Id);
    if (country == null)
      return false;
    country.Name = countryDTO.Name.Trim();
    country.Currency = countryDTO.Currency;
    unitOfWork.SCountriesRepository.Update(country);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (!await unitOfWork.SCountriesRepository.IsExistedAsync(id))
      return false;
    unitOfWork.SCountriesRepository.DeleteById(id);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }

}