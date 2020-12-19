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
            User user = GetUser();
            Store store = null;
            // check if the store is owned by the user
            if (user.Role == "admin")
            {
                store = _context.Store.FirstOrDefault(o => o.Id == postdto.StoreId);
            }
            else
            {
                store = _context.Store.FirstOrDefault(o => o.Id == postdto.StoreId && o.User.Id == user.Id);
            }
            if (store == null)
            {
                throw new Exception("Error getting store, is not registered or the user is not the owner");
            }
            Post post = new Post { Store = store, Title = postdto.Title, Content = postdto.Content };
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