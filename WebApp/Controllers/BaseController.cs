using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        public readonly WebAppContext _context;
        private readonly ILogger _logger;
        public BaseController(WebAppContext webappcontext, ILogger<BaseController> logger)
        {
            _context = webappcontext;
            _logger = logger;
        }

        public Object Save(Object o)
        {
            _context.Add(o);
            _context.SaveChanges();
            return o;
        }

        public User GetUser()
        {
            string username = User.Claims.FirstOrDefault(o => o.Type == "Name").Value;
            if (username == null)
            {
                throw new Exception("Error getting user information");
            }
            User user = _context.User.FirstOrDefault(o => o.Email == username);
            if (user == null)
            {
                throw new Exception("Error getting user from database");
            }
            return user;
        }

        public PostDto PostToDto(Post post)
        {
            CategoryDto cdto = CategoryToDto(post.Category);
            PostDto dto = new PostDto { Title = post.Title, Content = post.Content, CategoryDto = cdto };
            return dto;
        }

        public StoreDto StoreToDto(Store store)
        {
            StoreDto dto = new StoreDto { Id = store.Id, Name = store.Name };
            return dto;
        }

        public CategoryDto CategoryToDto(Category category)
        {
            CategoryDto dto = new CategoryDto { Id = category.Id, Name = category.Name };
            return dto;
        }

        public List<Store> GetStores() {

            User user = GetUser();

            List<Store> stores = null;
            if (user.Role == "admin")
            {
                stores = _context.Store.ToList();
            }
            else
            {
                stores = _context.Store.Where(o => o.User.Id == user.Id).ToList();
            }
            if (stores == null || stores.Count == 0)
            {
                throw new Exception("Error getting store information");
            }
            return stores;
        }
        public Store GetStore(int storeId)
        {
            User user = GetUser();
            Store store = null;
            // check if the store is owned by the user
            if (user.Role == "admin")
            {
                store = _context.Store.FirstOrDefault(o => o.Id == storeId);
            }
            else
            {
                store = _context.Store.FirstOrDefault(o => o.Id == storeId && o.User.Id == user.Id);
            }
            if (store == null)
            {
                throw new Exception("Error getting store, is not registered or the user is not the owner");
            }
            return store;
        }

        public Category GetCategory(int categoryId) {

            Category category = _context.Category.FirstOrDefault(o => o.Id == categoryId);

            if (category == null)
            {
                throw new Exception("Error getting category");
            }

            return category;
        }
    }
}