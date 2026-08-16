namespace Mahalak;

public class PCategoriesManager : IPCategoriesManager
{
  private readonly IUnitOfWork unitOfWork;

  public PCategoriesManager(IUnitOfWork unitOfWork) 
  { 
     this.unitOfWork = unitOfWork;
  }

  public async Task<List<PCategoryDTO>> GetAllAsync(CancellationToken ct=default)
  {
    var categories= await unitOfWork.PCategoriesRepository.GetAllAsync(ct);
    return categories.Select(c => new PCategoryDTO
    {
      Id = c.Id,
      Name = c.Name,
      SCategoryId = c.SCategoryId
    }).ToList();
  }

  public async Task<List<PCategoryDTO>> GetAllBySCategoryIdAsync(int id, CancellationToken ct=default)
  {
    var categories=await unitOfWork.PCategoriesRepository.GetAllBySCategoryIdAsync(id,ct);
    return categories.Select(c => new PCategoryDTO
    {
      Id = c.Id,
      Name = c.Name,
      SCategoryId = c.SCategoryId
    }).ToList();
  }

  public async Task<PCategoryDTO?> GetByIdAsync(int id)
  {
    var category = await  unitOfWork.PCategoriesRepository.GetByIdAsync(id);
    if (category == null)
      return null;
    return new PCategoryDTO
    {
      Id = category.Id,
      Name = category.Name,
      SCategoryId = category.SCategoryId
    };
  }

  public async Task AddAsync(PCategoryAddDTO categoryDTO)
  {
     unitOfWork.PCategoriesRepository.Add(new PCategory
    {
      Id = categoryDTO.Id,
      Name = categoryDTO.Name.Trim(),
      SCategoryId = categoryDTO.SCategoryId
    });
    await unitOfWork.SaveChangesAsync();
  }

  public async Task<bool> UpdateAsync(PCategoryUpdateDTO categoryDTO)
  {
    var category = await unitOfWork.PCategoriesRepository.GetByIdAsync(categoryDTO.Id);
    if (category == null)
      return false;
    category.Name = categoryDTO.Name.Trim();
    category.SCategoryId = categoryDTO.SCategoryId;
    unitOfWork.PCategoriesRepository.Update(category);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }

  public async Task<bool> DeleteAsync(int id)
  {
    if (!await unitOfWork.PCategoriesRepository.IsExistedAsync(id))
      return false;
     unitOfWork.PCategoriesRepository.DeleteById(id);
    
    return await unitOfWork.SaveChangesAsync() > 0;
  }
}
