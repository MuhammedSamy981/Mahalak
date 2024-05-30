
namespace Mahalak;
public class RatingsManager : IRatingsManager
{
    private readonly IUnitOfWork unitOfWork;

    public RatingsManager(IUnitOfWork unitOfWork)
    {
      this.unitOfWork=unitOfWork;
    }

    public async Task< List<GetAllRatingsWithCommentsInWaitingDTO>>  GetAllWithCommentsInWaiting()
    {
        var ratings=await unitOfWork.RatingsRepository.GetAllWithCommentsInWaiting();

        return ratings.Select(r=>new GetAllRatingsWithCommentsInWaitingDTO
        { 
            ID=r.ID,
            Value=r.Value,
            UserName=r.User!.Name,
            Comment=r.Comment,
            ShopID=r.ShopID,
            UserID=r.UserID
        }).ToList();
    }

    public GetRatingByIdDTO? GetById(int id)
    {
        var rating=unitOfWork.RatingsRepository.GetById(id);
        if(rating==null)
        {
            return null;
        }

        return new GetRatingByIdDTO
        {
            ID=rating.ID,
            Value=rating.Value,
            Comment=rating.Comment,
            ShopID=rating.ShopID,
            UserID=rating.UserID
        };
    }

    public bool Update(UpdateRatingDTO ratingDTO)
    {
        var rating=unitOfWork.RatingsRepository.GetById(ratingDTO.ID);
        if(rating==null)
        {
            return false;
        }

        rating.Value=ratingDTO.Value;
        rating.ShopID=ratingDTO.ShopID;
        rating.UserID=ratingDTO.UserID;

        unitOfWork.RatingsRepository.Update(rating);
        unitOfWork.SaveChanges();
        return true;
    }
    
    public void Add(AddRatingDTO ratingDTO)
    {
        Rating rating=new Rating
        {
          Value=ratingDTO.Value,
          Comment=ratingDTO.Comment,
          Datetime=DateTime.Now.ToString("dddd, dd MMMM yyyy h:mm tt"),
          ShopID=ratingDTO.ShopID,
          UserID=ratingDTO.UserID,
        };
        unitOfWork.RatingsRepository.Add(rating);
        unitOfWork.SaveChanges();
    }
    public bool Delete(int id)
    {
        var rating=unitOfWork.RatingsRepository.GetById(id);
        if(rating==null)
        {
            return false;
        }

        unitOfWork.RatingsRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return true;
    }

    public bool CheckExistence(Guid userId, int shopId)
    {
        return unitOfWork.RatingsRepository.CheckExistence(userId,shopId);
    }
}