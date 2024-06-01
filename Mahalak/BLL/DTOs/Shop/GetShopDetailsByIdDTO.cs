
namespace Mahalak;
public class GetShopDetailsByIdDTO
{

  public int ID { get; set; }
  public string Name = string.Empty;
  public GetUserByIdDTO? User { get; set; }
  public GetSCountryByIdDTO? Country{ get; set; }
  public GetSCityByIdDTO? City{ get; set; }
  public GetSAreaByIdDTO? Area{ get; set; }
  public List<GetAllProductsDTO>? Products{ get; set; }
  public List<GetAllRatingsDTO>? ClientsRatings{ get; set; }
  public AddRatingDTO? AddRating { get; set; }
}
