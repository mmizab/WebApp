using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Service
{
    public class BaseService
    {
        public WebAppContext Context { get; set; }
        public StoreService StoreService { get; set; }
        public CategoryService CategoryService { get; set; }
        public PostService PostService { get; set; }
        public BaseService(WebAppContext context)
        {
            Context = context;
            StoreService = new StoreService(context);
            CategoryService = new CategoryService(context);
            PostService = new PostService(context);
        }

        public Object Save(Object o)
        {
            Context.Add(o);
            Context.SaveChanges();
            return o;
        }
        public User GetUser()
        {
            string username = User.Claims.FirstOrDefault(o => o.Type == "Name").Value;
            if (username == null)
            {
                throw new Exception("Error getting user information");
            }
            User user = Context.User.FirstOrDefault(o => o.Email == username);
            if (user == null)
            {
                throw new Exception("Error getting user from database");
            }
            return user;
        }

    }
}
