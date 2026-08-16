namespace Mahalak;
public class SAreasManager : ISAreasManager
{
  private readonly IUnitOfWork unitOfWork;

  public SAreasManager(IUnitOfWork unitOfWork) =>  this.unitOfWork = unitOfWork;

  public async Task<List<SAreaDTO>> GetAllAsync(CancellationToken ct=default)
  {
    var areas = await unitOfWork.SAreasRepository.GetAllAsync(ct);
    return areas.Select(a => new SAreaDTO
    {
      Id = a.Id,
      Name = a.Name,
      CityId = a.CityId
    }).ToList();
  }

  public async Task<List<SAreaDTO>> GetAllByCityIdAsync(int id, CancellationToken ct=default)
  {
    var areas = await unitOfWork.SAreasRepository.GetAllByCityIdAsync(id,ct);
    return areas.Select(a => new SAreaDTO
    {
      Id = a.Id,
      Name = a.Name,
      CityId = a.CityId
    }).ToList();
  }

  public async Task<SAreaDTO?> GetByIdAsync(int id)
  {
    var area = await  unitOfWork.SAreasRepository.GetByIdAsync(id);
    if (area == null)
      return null;
    return new SAreaDTO
    {
      Id = area.Id,
      Name = area.Name,
      CityId = area.CityId
    };
  }

  public async Task AddAsync(SAreaAddDTO areaDTO)
  {
     unitOfWork.SAreasRepository.Add(new SArea
    {
      Id = areaDTO.Id,
      Name = areaDTO.Name.Trim(),
      CityId = areaDTO.CityId
    });
    await unitOfWork.SaveChangesAsync();
  }

  public async Task<bool> UpdateAsync(SAreaUpdateDTO areaDTO)
  {
    var area = await  unitOfWork.SAreasRepository.GetByIdAsync(areaDTO.Id);
    if (area == null)
      return false;
    area.Name = areaDTO.Name.Trim();
    area.CityId = areaDTO.CityId;
    unitOfWork.SAreasRepository.Update(area);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (!await unitOfWork.SAreasRepository.IsExistedAsync(id))
    return false;
    unitOfWork.SAreasRepository.DeleteById(id);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }

}
