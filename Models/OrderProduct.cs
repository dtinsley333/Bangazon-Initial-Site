using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BangazonDelta.Models
{
  public class OrderProduct
  {
      [Key]
      public int OrderProductId {get;set;}

      [Required]
      public int ProductId {get;}

      [Required]
      public int OrderId {get;}
  }
}