using Microsoft.AspNetCore.Mvc;
namespace Mahalak;
public class StarRatings : ViewComponent
{
    private readonly IUnitOfWork unitOfWork;

    public StarRatings(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id, CancellationToken ct)
    {
        int sum=0;
        double totalRatings=0;
        var ratings = await unitOfWork.RatingsRepository.GetAllByShopIdAsync(id,ct);

        foreach (var rating in ratings)
        {
            sum+=rating.Value;
        }
        
        
        if(ratings.Count!=0)
        {
          totalRatings=(double)sum/(double)ratings.Count;
        }

        return View(totalRatings);
    }
}