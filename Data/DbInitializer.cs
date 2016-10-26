using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BangazonDelta.Models;

namespace BangazonDelta.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BangazonDeltaContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonDeltaContext>>()))
            {
              // Look for any products.
              if (context.Product.Any())
              {
                  return;   // DB has been seeded
              }


            //   USERS
              var users = new User[]
              {
                  new User { 
                      FirstName = "Carson",
                      LastName = "Alexander",
                  },
                  new User { 
                      FirstName = "Steve",
                      LastName = "Brownlee",
                  },
                  new User { 
                      FirstName = "Tractor",
                      LastName = "Ryan",
                  }
              };

              foreach (User c in users)
              {
                  context.User.Add(c);
              }
              context.SaveChanges();


            //   PRODUCT TYPES
              var productTypes = new ProductType[]
              {
                  new ProductType { 
                      Name = "Electronics",
                      Description = "The Electronics Department"
                  },
                  new ProductType { 
                      Name = "Appliances",
                      Description = "Household appliances! Fridges! Washing machines!"
                  },
                  new ProductType { 
                      Name = "Housewares",
                      Description = "Coffee makers!! Vacuum cleaners!"
                  },
              };

              foreach (ProductType i in productTypes)
              {
                  context.ProductType.Add(i);
              }
              context.SaveChanges();


            //   PRODUCTS
              var products = new Product[]
              {
                  new Product { 
                      Description = "Colorful throw pillows to liven up your home",
                      ProductTypeId = productTypes.Single(s => s.Name == "Housewares").ProductTypeId,
                      Name = "Throw Pillow",
                      Price = 7.49,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Tractor").UserId
                  },
                  new Product { 
                      Description = "A 2012 iPod Shuffle. Headphones are included. 16G capacity.",
                      ProductTypeId = productTypes.Single(s => s.Name == "Electronics").ProductTypeId,
                      Name = "iPod Shuffle",
                      Price = 18.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Steve").UserId
                  },
                  new Product { 
                      Description = "Stainless steel refrigerator. Three years old. Minor scratches.",
                      ProductTypeId = productTypes.Single(s => s.Name == "Appliances").ProductTypeId,
                      Name = "Samsung refrigerator",
                      Price = 500.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Carson").UserId
                  }
              };

              foreach (Product i in products)
              {
                  context.Product.Add(i);
              }
              context.SaveChanges();


            //   ORDERS
              var orders = new Order[]
              {
                  new Order { 
                      UserId = users.Single(s => s.FirstName == "Tractor").UserId,
                      PaymentTypeId = null
                  },
                  new Order { 
                      UserId = users.Single(s => s.FirstName == "Steve").UserId,
                      PaymentTypeId = null
                  },
                  new Order { 
                      UserId = users.Single(s => s.FirstName == "Carson").UserId,
                      PaymentTypeId = null
                  }
              };

              foreach (Order i in orders)
              {
                  context.Order.Add(i);
              }
              context.SaveChanges();


            //   ORDERPRODUCTS
              var orderProducts = new OrderProduct[]
              {
                  new OrderProduct { 
                      ProductId = 1,
                      OrderId = 2
                  },
                  new OrderProduct { 
                      ProductId = 2,
                      OrderId = 3
                  },
                  new OrderProduct { 
                      ProductId = 3,
                      OrderId = 1
                  }
              };

              foreach (OrderProduct i in orderProducts)
              {
                  context.OrderProduct.Add(i);
              }
              context.SaveChanges();

          }
       }
    }
}