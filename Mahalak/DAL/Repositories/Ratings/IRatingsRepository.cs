namespace Mahalak;
public interface IRatingsRepository:IGenericRepository<Rating>
{
   Task<List<Rating>> GetAllWithCommentsInWaiting();
   Task<List<Rating>> GetAllByShopID(int id);
   bool CheckExistence(Guid userId,int shopId);
}