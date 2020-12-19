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

        public User GetUser() {
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

        public PostDto PostToDto(Post post) {
            CategoryDto cdto = CategoryToDto(post.Category);
            PostDto dto = new PostDto { Title = post.Title, Content = post.Content, CategoryDto = cdto};
            return dto;
        }

        public StoreDto StoreToDto(Store store) {
            StoreDto dto = new StoreDto { Id = store.Id, Name = store.Name };
            return dto;
        }

        public CategoryDto CategoryToDto(Category category) {
            CategoryDto dto = new CategoryDto { Id = category.Id, Name = category.Name};
            return dto;
        }

    }
}