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

        [Route("/")]
        [Route("/ofertes")]
        [Route("/ofertes/{category?}")]
        public IActionResult Index(string category)
        {
            List<PostDto> posts = new List<PostDto>();

            if (category != null)
            {
                posts = PostService.GetPosts(category);
            }
            else
            {
                posts = PostService.GetPosts(null);
            }
            List<CategoryDto> categories = CategoryService.GetCategoriesDto();
            

            HomeDto homeview = new HomeDto { CategoryDto = categories, PostDto = posts};

            return View(homeview);
        }

        [Route("/oferta/{id}")]
        public IActionResult GetPost(int id) {
            User user = GetUser();
            PostDto post = PostService.GetPost(id);
            if (post.StoreDto != null && post.StoreDto.UserId == user.Id)
            {
                post.StoreDto.Owner = true;
            }
            return View(post);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
