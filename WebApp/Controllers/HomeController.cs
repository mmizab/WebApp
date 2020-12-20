using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private CategoryService CategoryService { get; set; }
        private PostService PostService { get; set; }

        public HomeController(WebAppContext context) : base(context)
        {
            CategoryService = new CategoryService(context);
            PostService = new PostService(context);
        }

        public IActionResult Index()
        {
            List<CategoryDto> categories = CategoryService.GetCategoriesDto();
            List<PostDto> posts = PostService.GetPosts();

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
