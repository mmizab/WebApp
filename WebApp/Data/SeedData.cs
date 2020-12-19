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
            users.Add(new User { Email = "admin", Password = "1" , Role = "admin"});
            users.Add(new User { Email = "test@test.com", Password = "1", Role = "client"});

            context.AddRange(users);
            context.SaveChanges();

            // load test user to create test store 
            Store store = null;
            User test = users.FirstOrDefault(o => o.Email == "test@test.com");
            if ( test != null && test.Id != 0)
            {
                store = new Store { Name = "test store", User = test };
                context.Add(store);
                context.SaveChanges();
            }


            List<Category> category = new List<Category>
            {
                new Category { Name = "test" }
            };
            context.AddRange(category);
            context.SaveChanges();


            if (store != null && store.Id != 0) {
                List<Post> posts = new List<Post>
                {
                    new Post { Store = store, Title = "First post", CreateDate = DateTime.Now, Content = "First post content"},
                    new Post { Store = store, Title = "Second post", CreateDate = DateTime.Now, Content = "Second post content" },
                    new Post { Store = store, Title = "Third post", CreateDate = DateTime.Now, Content = "Third post content" }
                };

                context.AddRange(posts);
                context.SaveChanges();
            }
            
        }


    }
}
