namespace Mahalak;
public class PConditionsManager : IPConditionsManager
{
    private readonly IUnitOfWork unitOfWork;

    public PConditionsManager(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public List<GetAllPConditionsDTO> GetAll()
    {
        var conditions = unitOfWork.PConditionsRepository.GetAll();
        return conditions.Select(c => new GetAllPConditionsDTO
        {
            ID = c.ID,
            Name = c.Name
        }).ToList();
    }

    public GetPConditionByIdDTO? GetById(int id)
    {
        var condition = unitOfWork.PConditionsRepository.GetById(id);
        if (condition != null)
        {
            return new GetPConditionByIdDTO
            {
                ID = condition.ID,
                Name = condition.Name
            };
        }
        return null;
    }

    public void Add(AddPConditionDTO conditionDTO)
    {
        PCondition condition=new PCondition
        {
            ID=conditionDTO.ID,
            Name=conditionDTO.Name
        };
        unitOfWork.PConditionsRepository.Add(condition);
        unitOfWork.SaveChanges();

    }

    public bool Update(UpdatePConditionDTO conditionDTO)
    {
        var condition=unitOfWork.PConditionsRepository.GetById(conditionDTO.ID);
        if(condition==null)
        {
            return false;
        }
        condition.Name=conditionDTO.Name;
        unitOfWork.PConditionsRepository.Update(condition);
        unitOfWork.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var condition=unitOfWork.PConditionsRepository.GetById(id);
        if(condition==null)
        {
            return false;
        }
        unitOfWork.PConditionsRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return true;
    }
}