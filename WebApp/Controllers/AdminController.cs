using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private StoreService StoreService { get; set; }
        private CategoryService CategoryService { get; set; }
        private PostService PostService { get; set; }
        public AdminController(WebAppContext context):base(context){
            StoreService = new StoreService(context);
            CategoryService = new CategoryService(context);
            PostService = new PostService(context);
        }

        public IActionResult Index()
        {
            User user = GetUser();
            List<StoreDto> storesdtos = StoreService.GetStoresDto(user);
            List<CategoryDto> categorydtos = CategoryService.GetCategoriesDto(); 

            AdminPostDto post = new AdminPostDto { StoreDto = storesdtos, CategoryDto = categorydtos};
            return View(post);
        }


        [HttpPost]
        public IActionResult CreatePost(AdminPostDto postdto)
        {
            User user = GetUser();
            Store store = StoreService.GetStore(postdto.StoreId, user);
            Category category = CategoryService.GetCategory(postdto.CategoryId);
            PostService.PostSave(postdto, store, category);
            return RedirectToAction("Index");
        }
    }
}