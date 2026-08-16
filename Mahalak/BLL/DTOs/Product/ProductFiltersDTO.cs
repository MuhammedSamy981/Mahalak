using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class ProductFiltersDTO
{
  public string Name { get; set; }= string.Empty;
  public int CategoryId{ get; set; }
  public decimal MinPrice { get; set; }
  public decimal MaxPrice { get; set; }
  public int ConditionId { get; set; }
}
