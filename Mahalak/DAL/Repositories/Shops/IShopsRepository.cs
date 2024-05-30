namespace Mahalak;
public interface IShopsRepository:IGenericRepository<Shop>
{
  List<Shop> GetAllWithFilters(int categoryID,int countryID, int cityID, int areaID);
  List<Shop> GetAllByUserId(Guid id);
   List<Shop> GetAllByName(string name);

  Shop? GetAllDetailsById(int? id);
}