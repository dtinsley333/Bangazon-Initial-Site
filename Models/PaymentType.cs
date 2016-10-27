using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonDelta.Models
{
  public class PaymentType
  //now we define what we want our table to look like...//
  {
    [Key]
    //this is the Primary Key from our ERD diagram//
    public int PaymentTypeId {get;set;}

    [Required]
    //we want AccountNumber to be required...//
    public int AccountNumber {get;set;}

    [Required]
    //we want CVV to be required...//
    public int CVV { get; set; }

    [Required]
    public DateTime Expiration { get; set; }

    [Required]
    public int UserId { get; set; }

    public User User {get;set;}
    
  }
}