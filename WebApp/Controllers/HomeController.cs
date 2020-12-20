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
using WebApp.Service;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger _logger;
        private CategoryService CategoryService { get; set; }
        public HomeController(WebAppContext webappcontext, ILogger<HomeController> logger) : base(webappcontext, logger)
        {
            _logger = logger;
            CategoryService = new CategoryService(webappcontext);
        }




        public IActionResult Index()
        {
            List<CategoryDto> categories = CategoryService.GetCategoriesDto();
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
