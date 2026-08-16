
namespace Mahalak;

public class ShopDetailsDTO
{
  public int Id { get; set; }
  public string Name { get; set; }= string.Empty;
  public UserDTO? User { get; set; }
  public SCategoryDTO? Category { get; set; }
  public SCountryDTO? Country { get; set; }
  public SCityDTO? City { get; set; }
  public SAreaDTO? Area { get; set; }
  public List<ProductInShopDTO>? Products { get; set; }
  public string Status { get; set; } = string.Empty;
}
