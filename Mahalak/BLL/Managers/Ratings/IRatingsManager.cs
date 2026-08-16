namespace Mahalak;

public interface IRatingsManager
{
  Task<List<RatingDTO>> GetAllWithCommentsInWaiting(CancellationToken ct=default);

Task<List<RatingDTO>> GetAllByShopIdAsync(int id, CancellationToken ct=default);

  Task<RatingDTO?> GetByIdAsync(int id);

  Task AddAsync(RatingAddDTO ratingDTO);

  Task<bool> UpdateAsync(RatingUpdateDTO ratingDTO);

  Task<bool> DeleteAsync(int id);

  Task<bool> CheckExistenceAsync(string userId, int shopId);
  
    Task<bool> EditCommentStatusAsync(int id, string status);
}