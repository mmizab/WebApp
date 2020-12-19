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
            users.Add(new User { Email = "admin", Password = "1" });
            users.Add(new User { Email = "test@test.com", Password = "1" });

            context.AddRange(users);
            context.SaveChanges();

            // load test user to create test store 
            User test = users.FirstOrDefault(o => o.Email == "test@test.com");
            if ( test != null && test.Id != 0)
            {
                Store store = new Store { Name = "test store", User = test };
                context.Add(store);
                context.SaveChanges();
            }
            
        }


    }
}
