using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Service;

namespace WebApp.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        public AdminController(WebAppContext context):base(context){
        }
        public IActionResult Index()
        {
            List<StoreDto> storesdtos = StoreService.GetStoresDto();
            List<CategoryDto> categorydtos = CategoryService.GetCategoriesDto(); 

            AdminPostDto post = new AdminPostDto { StoreDto = storesdtos, CategoryDto = categorydtos};
            return View(post);
        }


        [HttpPost]
        public IActionResult CreatePost(AdminPostDto postdto)
        {
            
            return RedirectToAction("Index");
        }
    }
}