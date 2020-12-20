using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        public AdminController(WebAppContext webappcontext, ILogger<AdminController> logger) : base(webappcontext, logger)
        {

        }
        public IActionResult Index()
        {
            User user = GetUser();
            List<Store> stores = new List<Store>();
            List<StoreDto> storesdtos = new List<StoreDto>();
            List<CategoryDto> categorydtos = new List<CategoryDto>();

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

            foreach (var item in stores)
            {
                storesdtos.Add(StoreToDto(item));
            }
            List<Category> categorys = _context.Category.ToList();
            foreach (var item in categorys)
            {
                categorydtos.Add(CategoryToDto(item));
            }

            AdminPostDto post = new AdminPostDto { StoreDto = storesdtos, CategoryDto = categorydtos};
            return View(post);
        }


        [HttpPost]
        public IActionResult CreatePost(AdminPostDto postdto)
        {
            Store store = GetStore(postdto.StoreId);
            Category category = GetCategory(postdto.CategoryId);
            Post post = new Post { Store = store, Title = postdto.Title, Content = postdto.Content, Category = category };
            post.CreateDate = DateTime.Now;
            Save(post);
            if (post.Id == 0)
            {
                throw new Exception("Error saving post");
            }
            return RedirectToAction("Index");
        }
    }
}