using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(WebAppContext webappcontext):base(webappcontext)
        {

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreatePostRazor(Post post) {
            CreatePost(post);
            return View("Index", post);
        }


        [HttpPost]
        public IActionResult CreatePost(Post post) {
            post.CreateDate = DateTime.Now;
            Save(post);
            return Ok(post);
        }
    }
}