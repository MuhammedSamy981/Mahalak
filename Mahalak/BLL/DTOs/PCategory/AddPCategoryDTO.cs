
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class AddPCategoryDTO
{
  public int ID{ get; set; }
  public string Name { get; set; }= string.Empty;
  public int SCategoryID{ get; set; }

}
