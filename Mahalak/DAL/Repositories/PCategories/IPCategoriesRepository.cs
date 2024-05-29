namespace Mahalak;
public interface IPCategoriesRepository:IGenericRepository<PCategory>
{
   List<PCategory> GetAllBySCategoryId(int id);
}