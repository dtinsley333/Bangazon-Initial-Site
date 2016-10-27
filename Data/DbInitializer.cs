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
                      Description = "Colored Pencils. The brightest pencils on the market",
                      ProductTypeId = productTypes.Single(s => s.Name == "Office Supplies").ProductTypeId,
                      Name = "Colored Pencils",
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
                      ProductTypeId = productTypes.Single(s => s.Name == "Electronics").ProductTypeId,
                      Name = "Samsung refrigerator",
                      Price = 500.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Carson").UserId
                  },
                  new Product { 
                      Description = "The best headphones to combat construction.",
                      ProductTypeId = productTypes.Single(s => s.Name == "Electronics").ProductTypeId,
                      Name = "Construction Headphones",
                      Price = 70.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Carson").UserId
                  },
                  new Product { 
                      Description = "Red Stapler. The one straight out of the Office Space set!",
                      ProductTypeId = productTypes.Single(s => s.Name == "Office Supplies").ProductTypeId,
                      Name = "Red Stapler",
                      Price = 999.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Carson").UserId
                  },
                  new Product { 
                      Description = "The best paperclips you've ever used. A non-slip, secure hold to keep all of your documents together.",
                      ProductTypeId = productTypes.Single(s => s.Name == "Paperclips").ProductTypeId,
                      Name = "Office Supplies",
                      Price = 1.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Carson").UserId
                  },
                  new Product { 
                      Description = "Gel pens with the smoothest writing on the market.",
                      ProductTypeId = productTypes.Single(s => s.Name == "Pens").ProductTypeId,
                      Name = "Office Supplies",
                      Price = 2.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Carson").UserId
                  },
                  new Product { 
                      Description = "Yummy biscuits that even humans can eat! Healthy for your dog, healthy for you.",
                      ProductTypeId = productTypes.Single(s => s.Name == "Biscuits").ProductTypeId,
                      Name = "Dog Stuff",
                      Price = 24.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Carson").UserId
                  },
                  new Product { 
                      Description = "You're going to be jealous of your dog this bed is so comfortable.",
                      ProductTypeId = productTypes.Single(s => s.Name == "Dog Stuff").ProductTypeId,
                      Name = "Dog Bed",
                      Price = 42.00,
                      Sold = false,
                      UserId = users.Single(s => s.FirstName == "Carson").UserId
                  },
                  new Product { 
                      Description = "It looks like a ball you want to play tennis with, but this is exclusively for your dog.",
                      ProductTypeId = productTypes.Single(s => s.Name == "Dog Stuff").ProductTypeId,
                      Name = "Tennis Ball",
                      Price = 10.00,
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


              //   SUBCATEGORIES. MD - Seeding the database.
              var productSubType = new ProductSubType[]
              {
                  new ProductSubType { 
                      Name: "Pencils",
                      ProductTypeId: "Office Supplies"
                  },
                  new ProductSubType { 
                      Name: "Stationary"
                      ProductTypeId: "Office Supplies"
                  },
                  new ProductSubType { 
                      Name: "Markers"
                      ProductTypeId: "Office Supplies"
                  },
                  new ProductSubType { 
                      Name: "Music"
                      ProductTypeId: "Electronics"
                  },
                  new ProductSubType { 
                      Name: "Appliances"
                      ProductTypeId: "Electronics"
                  },
                  new ProductSubType { 
                      Name: "Phones"
                      ProductTypeId: "Electronics"
                  },
                  new ProductSubType { 
                      Name: "Treats"
                      ProductTypeId: "Dog Stuff"
                  },
                  new ProductSubType { 
                      Name: "Bedding"
                      ProductTypeId: "Dog Stuff"
                  },
                  new ProductSubType { 
                      Name: "Toys"
                      ProductTypeId: "Dog Stuff"
                  },
                  new ProductSubType { 
                      Name: "Other"
                      ProductTypeId: "Dog Stuff"
                  }
              };

              foreach (ProductSubType i in productSubType)
              {
                  context.ProductSubType.Add(i);
              }
              context.SaveChanges();

          }
       }
    }
}