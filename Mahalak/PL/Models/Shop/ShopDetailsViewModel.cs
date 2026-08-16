
namespace Mahalak;

public class ShopDetailsViewModel
{

  public int Id { get; set; }
  public string Name { get; set; }= string.Empty;
  public string CategoryName { get; set; }= string.Empty;
  public string Address { get; set; }= string.Empty;
  public string OwnerName { get; set; }= string.Empty;
  public string OwnerNumber { get; set; }= string.Empty;
  public List<ProductInShopViewModel>? Products { get; set; }
  public string Status { get; set; } = string.Empty;
}
