namespace Mahalak;
public class PConditionsManager : IPConditionsManager
{
  private readonly IUnitOfWork unitOfWork;

  public PConditionsManager(IUnitOfWork unitOfWork) =>  this.unitOfWork = unitOfWork;

  public async Task<List<PConditionDTO>> GetAllAsync(CancellationToken ct=default)
  {
    var conditions = await unitOfWork.PConditionsRepository.GetAllAsync(ct);
    return conditions.Select(c => new PConditionDTO
    {
      Id = c.Id,
      Name = c.Name
    }).ToList();
  }

  public async Task<PConditionDTO?> GetByIdAsync(int id)
  {
    var condition = await unitOfWork.PConditionsRepository.GetByIdAsync(id);
    if (condition == null)
      return null;
    return new PConditionDTO()
    {
      Id = condition.Id,
      Name = condition.Name
    };
  }

  public async Task AddAsync(PConditionAddDTO conditionDTO)
  {
     unitOfWork.PConditionsRepository.Add(new PCondition()
    {
      Id = conditionDTO.Id,
      Name = conditionDTO.Name.Trim()
    });
    await unitOfWork.SaveChangesAsync();
  }

  public async Task<bool> UpdateAsync(PConditionUpdateDTO conditionDTO)
  {
    var condition = await  unitOfWork.PConditionsRepository.GetByIdAsync(conditionDTO.Id);
    if (condition == null)
      return false;
    condition.Name = conditionDTO.Name.Trim();
     unitOfWork.PConditionsRepository.Update(condition);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (!await unitOfWork.PConditionsRepository.IsExistedAsync(id))
      return false;
     unitOfWork.PConditionsRepository.DeleteById(id);
    int num = await  unitOfWork.SaveChangesAsync();
    return await unitOfWork.SaveChangesAsync() > 0;
  }
}
