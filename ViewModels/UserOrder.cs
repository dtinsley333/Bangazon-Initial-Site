using System.Collections.Generic;
using System.Linq;
using BangazonDelta.Models;
using BangazonDelta.Data;

namespace BangazonDelta.ViewModels
{
    public class UserOrder : BaseViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<OrderProduct> OrderProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public UserOrder(BangazonDeltaContext ctx) : base(ctx) { }
    }
}