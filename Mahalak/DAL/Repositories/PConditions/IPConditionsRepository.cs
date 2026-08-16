namespace Mahalak;
public interface IPConditionsRepository:IGenericRepository<PCondition>
{
   Task<bool> IsExistedAsync(int id);
}