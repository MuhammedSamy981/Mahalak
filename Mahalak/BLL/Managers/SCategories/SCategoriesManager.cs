namespace Mahalak;

public class SCategoriesManager : ISCategoriesManager
{
  private readonly IUnitOfWork unitOfWork;

  public SCategoriesManager(IUnitOfWork unitOfWork) =>  this.unitOfWork = unitOfWork;

  public async Task<List<SCategoryDTO>> GetAllAsync(CancellationToken ct=default)
  {
    var categories = await unitOfWork.SCategoriesRepository.GetAllAsync(ct);
    return categories.Select(c => new SCategoryDTO
    {
      Id = c.Id,
      Name = c.Name
    }).ToList();
  }

  public async Task<SCategoryDTO?> GetByIdAsync(int id)
  {
    var category = await  unitOfWork.SCategoriesRepository.GetByIdAsync(id);
    if (category == null)
      return null;
    return new SCategoryDTO
    {
      Id = category.Id,
      Name = category.Name
    };
  }

  public async Task AddAsync(SCategoryAddDTO categoryDTO)
  {
    unitOfWork.SCategoriesRepository.Add(new SCategory
    {
      Id = categoryDTO.Id,
      Name = categoryDTO.Name.Trim()
    });
    await unitOfWork.SaveChangesAsync();
  }

  public async Task<bool> UpdateAsync(SCategoryUpdateDTO categoryDTO)
  {
    var category = await  unitOfWork.SCategoriesRepository.GetByIdAsync(categoryDTO.Id);
    if (category == null)
      return false;
    category.Name = categoryDTO.Name.Trim();
    unitOfWork.SCategoriesRepository.Update(category);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (!await unitOfWork.SCategoriesRepository.IsExistedAsync(id))
      return false;
    unitOfWork.SCategoriesRepository.DeleteById(id);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }

}
