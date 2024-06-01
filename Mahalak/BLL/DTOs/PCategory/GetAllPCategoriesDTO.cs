using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllPCategoriesDTO
{  
  public int ID{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int SCategoryID{ get; set; }
}
