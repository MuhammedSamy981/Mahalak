
namespace Mahalak;
public class SCitiesManager : ISCitiesManager
{
  private readonly IUnitOfWork unitOfWork;

  public SCitiesManager(IUnitOfWork unitOfWork) =>  this.unitOfWork = unitOfWork;

  public async Task<List<SCityDTO>> GetAllAsync(CancellationToken ct=default)
  {
    var cities=await  unitOfWork.SCitiesRepository.GetAllAsync(ct);
    return cities.Select(c => new SCityDTO
    {
      Id = c.Id,
      Name = c.Name,
      CountryId = c.CountryId
    }).ToList();
  }

  public async Task<List<SCityDTO>> GetAllByCountryIdAsync(int id, CancellationToken ct=default)
  {
    var cities = await unitOfWork.SCitiesRepository.GetAllByCountryIdAsync(id,ct);
    return cities.Select(c => new SCityDTO
    {
      Id = c.Id,
      Name = c.Name,
      CountryId = c.CountryId
    }).ToList();
  }

  public async Task<SCityDTO?> GetByIdAsync(int id)
  {
   var city = await unitOfWork.SCitiesRepository.GetByIdAsync(id);
    if (city == null)
      return null;
    return new SCityDTO
    {
      Id = city.Id,
      Name = city.Name,
      CountryId = city.CountryId
    };
  }

  public async Task AddAsync(SCityAddDTO cityDTO)
  {
    unitOfWork.SCitiesRepository.Add(new SCity()
    {
      Id = cityDTO.Id,
      Name = cityDTO.Name.Trim(),
      CountryId = cityDTO.CountryId
    });
    await unitOfWork.SaveChangesAsync();
  }

  public async Task<bool> UpdateAsync(SCityUpdateDTO cityDTO)
  {
    var city = await  unitOfWork.SCitiesRepository.GetByIdAsync(cityDTO.Id);
    if (city == null)
      return false;
    city.Name = cityDTO.Name.Trim();
    city.CountryId = cityDTO.CountryId;
    unitOfWork.SCitiesRepository.Update(city);
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (!await unitOfWork.SCitiesRepository.IsExistedAsync(id))
      return false;
    unitOfWork.SCitiesRepository.DeleteById(id);
    return await unitOfWork.SaveChangesAsync() > 0;
  }

}
