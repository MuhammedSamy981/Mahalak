using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllProductImagesDTO
{  
  public int ID{ get; set; }
  public string Name { get; set; }= string.Empty;

    public int ProductID{ get; set; }

}
