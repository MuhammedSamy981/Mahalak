namespace Mahalak;
public class PCategoriesManager : IPCategoriesManager
{
  
    private readonly IUnitOfWork unitOfWork;

    public PCategoriesManager(IUnitOfWork unitOfWork)
    {
      this.unitOfWork=unitOfWork;
    }

    public List<GetAllPCategoriesDTO> GetAll()
    {
        var categories=unitOfWork.PCategoriesRepository.GetAll();
        return categories.Select(c=>new GetAllPCategoriesDTO
        {
            ID=c.ID,
            Name=c.Name,
            SCategoryID=c.SCategoryID
        }).ToList();
    }

    public List<GetAllPCategoriesBySCategoryIdDTO> GetAllBySCategoryId(int id)
    {
       var categories=unitOfWork.PCategoriesRepository.GetAllBySCategoryId(id);
        return categories.Select(c=>new GetAllPCategoriesBySCategoryIdDTO
        {
            ID=c.ID,
            Name=c.Name,
            SCategoryID=c.SCategoryID
        }).ToList();
    }
    public GetPCategoryByIdDTO? GetById(int id)
    {
        var category=unitOfWork.PCategoriesRepository.GetById(id);
        if(category==null)
        {
            return null;
        }

        return new GetPCategoryByIdDTO
        {
            ID=category.ID,
            Name=category.Name,
            SCategoryID=category.SCategoryID
        };
    }

    public void Add(AddPCategoryDTO categoryDTO)
    {
       PCategory category=new PCategory
       {
            ID=categoryDTO.ID,
            Name=categoryDTO.Name,
            SCategoryID=categoryDTO.SCategoryID
       };

       unitOfWork.PCategoriesRepository.Add(category);
       unitOfWork.SaveChanges();
       
    }

    public bool Update(UpdatePCategoryDTO categoryDTO)
    {
        var category=unitOfWork.PCategoriesRepository.GetById(categoryDTO.ID);
        if(category==null)
        {
            return false;
        }
        category.Name=categoryDTO.Name;
        category.SCategoryID=categoryDTO.SCategoryID;

       unitOfWork.PCategoriesRepository.Update(category);
       unitOfWork.SaveChanges();  
       return true; 
    }
    
    public bool Delete(int id)
    {
        var category=unitOfWork.PCategoriesRepository.GetById(id);
        if(category==null)
        {
            return false;
        }

       unitOfWork.PCategoriesRepository.DeleteById(id);
       unitOfWork.SaveChanges();  
       return true; 
    }


}