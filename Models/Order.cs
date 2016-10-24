using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BangazonDelta.Models
{
  public class Order
  {
    [Key]
    public int OrderId {get;set;}

    [Required]
    
    public int UserId {get;set;}

    [Required]
    //int? means that PaymentTypeId can contain an integer or be null...//
    public int? PaymentTypeId { get; set; }

  }
}