namespace Mahalak;
public interface IPConditionsManager
{
  Task<List<PConditionDTO>> GetAllAsync(CancellationToken ct=default);

  Task<PConditionDTO?> GetByIdAsync(int id);

  Task AddAsync(PConditionAddDTO conditionDTO);

  Task<bool> UpdateAsync(PConditionUpdateDTO conditionDTO);

  Task<bool> DeleteAsync(int id);
}