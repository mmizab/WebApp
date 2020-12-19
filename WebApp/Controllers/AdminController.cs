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
        public AdminController(WebAppContext webappcontext, ILogger<AdminController> logger):base(webappcontext,logger)
        {

        }
        public IActionResult Index()
        {
            User user = GetUser();
            Store store = _context.Store.FirstOrDefault(o => o.User.Id == user.Id);
            if (store == null)
            {
                throw new Exception("Error getting store information");
            }
            PostDto post = new PostDto { StoreId = store.Id};
            return View(post);
        }


        [HttpPost]
        public IActionResult CreatePostRazor(PostDto post) {
            CreatePost(post);
            return View("Index", post);
        }


        [HttpPost]
        public IActionResult CreatePost(PostDto postdto) {

            User user = GetUser();

            // check if the store is owned by the user
            Store store = _context.Store.FirstOrDefault(o => o.Id == postdto.StoreId && o.User.Id == user.Id);
            if (store == null)
            {
                throw new Exception("Error getting store, is not registered or the user is not the owner");
            }
            Post post = new Post { Store = store, Title = postdto.Title, Content = postdto.Content};
            post.CreateDate = DateTime.Now;
            Save(post);
            if (post.Id == 0)
            {
                throw new Exception("Error saving post");
            }
            return Ok(post);
        }
    }
}