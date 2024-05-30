
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllProductDetailsByIdDTO
{
  public int ID{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int ShopID{ get; set; }
  public string Price { get; set; }= string.Empty;
  public GetPCategoryByIdDTO? Category { get; set; }
  public GetPConditionByIdDTO? Condition { get; set; }
  public List<GetAllProductImagesDTO>? Images { get; set; }
  public string Describtion { get; set; }= string.Empty;
  public string Status { get; set; }=string.Empty;

}
