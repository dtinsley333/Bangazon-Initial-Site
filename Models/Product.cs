using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangazonDelta.Models
{
  public class Product
  {
    [Key]
    public int ProductId {get;set;}

    [Required]
    [StringLength(55)]
    public string Name { get; set; }

    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public bool Sold { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User {get;set;}

    [Required]
    public int ProductTypeId { get; set; }
    public ICollection<OrderProduct> OrderProducts {get;set;}

    [Required]
    public int ProductSubTypeId {get; set;}
  }
}