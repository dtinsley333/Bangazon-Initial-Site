using System.Collections.Generic;
using System.Linq;
using BangazonDelta.Models;
using BangazonDelta.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BangazonDelta.ViewModels
{
  public class BaseViewModel
  {
    public IEnumerable<SelectListItem> UserId { get; set; }
    private BangazonDeltaContext context;
    // private ActiveUser singleton = ActiveUser.Instance;
    // public User ChosenUser 
    // {
    //   get
    //   {
    //     // Get the current value of the customer property of our singleton
    //     Customer customer = singleton.Customer;

    //     // If no customer has been chosen yet, it's value will be null
    //     if (customer == null)
    //     {
    //       // Return fake customer for now
    //       return new Customer () {
    //         FirstName = "Create",
    //         LastName = "Account"
    //       };
    //     }

    //     // If there is a customer chosen, return it
    //     return customer;
    //   }
    //   set
    //   {
    //     if (value != null)
    //     {
    //       singleton.Customer = value;
    //     }
    //   }
    // }
    public BaseViewModel(BangazonDeltaContext ctx)
    {
        context = ctx;
        this.UserId = context.User
            .OrderBy(l => l.LastName)
            .AsEnumerable()
            .Select(li => new SelectListItem { 
                Text = $"{li.FirstName} {li.LastName}",
                Value = li.UserId.ToString()
            });
    }
    public BaseViewModel() { } 
  }
}