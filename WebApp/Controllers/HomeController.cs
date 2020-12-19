using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger _logger;
        public HomeController(WebAppContext webappcontext, ILogger<HomeController> logger) : base(webappcontext, logger)
        {
            _logger = logger;
        }

        public List<PostDto> GetPosts()
        {
            List<Post> posts = _context.Post.Include( o => o.Category).ToList();
            List<PostDto> dtos = new List<PostDto>();
            foreach (var item in posts)
            {
                dtos.Add(PostToDto(item));
            }
            return dtos;
        }

        public List<CategoryDto> GetCategories() {

            List<Category> categories = _context.Category.ToList();
            List<CategoryDto> dtos = new List<CategoryDto>();
            foreach (var item in categories)
            {
                dtos.Add(CategoryToDto(item));
            }
            return dtos;
        }
        public IActionResult Index()
        {
            List<CategoryDto> categories = GetCategories();
            List<PostDto> posts = GetPosts();

            HomeDto homeview = new HomeDto { CategoryDto = categories, PostDto = posts};

            return View(homeview);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
