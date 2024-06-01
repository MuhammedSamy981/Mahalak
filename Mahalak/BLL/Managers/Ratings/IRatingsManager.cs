namespace Mahalak;
public interface IRatingsManager
{
    Task<List<GetAllRatingsWithCommentsInWaitingDTO>>  GetAllWithCommentsInWaiting();
    GetRatingByIdDTO? GetById(int id);
    void Add(AddRatingDTO ratingDTO);
    bool Update(UpdateRatingDTO ratingDTO);
    bool Delete(int id);
    bool CheckExistence(Guid userId,int shopId);
}