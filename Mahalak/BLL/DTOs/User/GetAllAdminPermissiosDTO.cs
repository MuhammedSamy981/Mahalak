
using System.ComponentModel.DataAnnotations;

namespace Mahalak;
public class GetAllAdminPermissiosDTO
{
 public AddSCategoryDTO? SCategory {get; set;}
 public AddSCountryDTO? Country {get; set;}
 public AddSCityDTO? City {get; set;}
 public AddSAreaDTO? Area{get; set;}
 public AddPCategoryDTO? PCategory {get; set;}
 public AddPConditionDTO? Condition {get; set;}
 public GetUserByEmailOrPhoneDTO? User {get; set;}
 public string? UserSearch {get; set;}
 public string? ShopSearch {get; set;}
 public string? ProductSearch {get; set;}
 public string? DistinctivePeriod {get; set;}
 public string? AddingShopsCount {get; set;}
 public int? AddingShopsPeriod {get; set;}
}
