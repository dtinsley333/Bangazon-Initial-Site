using System.Collections.Generic;
using System.Linq;
using BangazonDelta.Models;
using BangazonDelta.Data;

namespace BangazonDelta.ViewModels
{
    public class UserOrder : BaseViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<OrderProduct> OrderProduct { get; set; }
        public Order Order { get; set; }
        public UserOrder(BangazonDeltaContext ctx) : base(ctx) { }
    }
}