using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BangazonDelta.Models
{
  public class User
  {
    [Key]
    public int UserId {get;set;}

    [Required]
    [StringLength(55)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(55)]
    public string LasttName { get; set; }

  }
}