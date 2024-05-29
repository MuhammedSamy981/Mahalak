namespace Mahalak;
public class SCategoriesManager : ISCategoriesManager
{    private readonly IUnitOfWork unitOfWork;

    public SCategoriesManager(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public List<GetAllSCategoriesDTO> GetAll()
    {
        var categories = unitOfWork.SCategoriesRepository.GetAll();
        return categories.Select(c => new GetAllSCategoriesDTO
        {
            ID = c.ID,
            Name = c.Name
        }).ToList();
    }

    public GetSCategoryByIdDTO? GetById(int id)
    {
        var category = unitOfWork.SCategoriesRepository.GetById(id);
        if (category != null)
        {
            return new GetSCategoryByIdDTO
            {
                ID = category.ID,
                Name = category.Name
            };
        }
        return null;
    }

    public void Add(AddSCategoryDTO categoryDTO)
    {
        SCategory category=new SCategory
        {
            ID=categoryDTO.ID,
            Name=categoryDTO.Name
        };
        unitOfWork.SCategoriesRepository.Add(category);
        unitOfWork.SaveChanges();

    }

    public bool Update(UpdateSCategoryDTO categoryDTO)
    {
        var category=unitOfWork.SCategoriesRepository.GetById(categoryDTO.ID);
        if(category==null)
        {
            return false;
        }
        category.Name=categoryDTO.Name;
        unitOfWork.SCategoriesRepository.Update(category);
        unitOfWork.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var category=unitOfWork.SCategoriesRepository.GetById(id);
        if(category==null)
        {
            return false;
        }
        unitOfWork.SCategoriesRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return true;
    }
}