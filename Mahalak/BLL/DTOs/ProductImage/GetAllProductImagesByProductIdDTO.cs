using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllProductImagesByProductIdDTO
{  
  public int ID{ get; set; }
  public string Name { get; set; }= string.Empty;

  public int ProductID{ get; set; }

}
