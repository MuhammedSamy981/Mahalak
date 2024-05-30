namespace Mahalak;
public interface ISAreasRepository:IGenericRepository<SArea>
{
    List<SArea> GetAllByCityId(int id);
}