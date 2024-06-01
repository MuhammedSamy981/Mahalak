namespace Mahalak;
public interface IPConditionsManager
{
    List<GetAllPConditionsDTO> GetAll();
    GetPConditionByIdDTO? GetById(int id);
    void Add(AddPConditionDTO conditionDTO);
    bool Update(UpdatePConditionDTO conditionDTO);
    bool Delete(int id);

}