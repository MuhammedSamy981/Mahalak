namespace Mahalak;
public interface ISCategoriesRepository:IGenericRepository<SCategory>
{
    Task<bool> IsExistedAsync(int id);
}