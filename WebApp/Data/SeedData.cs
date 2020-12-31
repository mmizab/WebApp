using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Models;

namespace WebApp.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebAppContext>>()))
            {
                SeedData.Populate(context);
            }
        }

        public static void Populate(WebAppContext context) {
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            List<User> users = new List<User>();
            users.Add(new User { Email = "admin", Password = "1" , Role = "admin", Name = "admin"});
            users.Add(new User { Email = "test", Password = "1", Role = "client", Name = "test"});

            context.AddRange(users);
            context.SaveChanges();

            // load test user to create test store 
            Store store = null;
            User test = users.FirstOrDefault(o => o.Email == "admin");
            if ( test != null && test.Id != 0)
            {
                store = new Store { Name = "test store", User = test };
                context.Add(store);
                context.SaveChanges();
            }


            List<Category> category = new List<Category>
            {
                new Category { Name = "Alimentació" },
                new Category { Name = "Llar" },
                new Category { Name = "Floristeria" },
                new Category { Name = "Cine" },
                new Category { Name = "Informàtica" },
                new Category { Name = "Immobiliaria" },
                new Category { Name = "Electrodomestic" },
                new Category { Name = "Tenda de regals" },
                new Category { Name = "Joieria" },
                new Category { Name = "Panaderia" },
                new Category { Name = "Llibreria" },
                new Category { Name = "Roba" },
                new Category { Name = "Gelateria" },
                new Category { Name = "Adm de loteria" },
                new Category { Name = "Estancs" },
                new Category { Name = "Farmàcia" },
                new Category { Name = "test" }
            };
            context.AddRange(category);
            context.SaveChanges();

        }


    }
}
