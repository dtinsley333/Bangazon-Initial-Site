using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonDelta.Models
{
  public class ProductSubType
  {
    [Key]
    public int ProductSubTypeId {get;set;}
    [Required]
    public string name {get;set;}
    [Required]
    public int ProductTypeId { get; set; }
    public ProductType ProductType {get;set;}
  }
}