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
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User { Email="admin", Password="1"},
                    new User { Email="test@test.com", Password="1"}
                    );
                context.SaveChanges();
            }
        }
    }
}
