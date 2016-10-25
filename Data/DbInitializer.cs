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
          }
       }
    }
}