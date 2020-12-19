using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger _logger;
        public HomeController(WebAppContext webappcontext, ILogger<HomeController> logger) : base(webappcontext, logger)
        {
            _logger = logger;
        }

        public List<Post> GetPosts()
        {
            List<Post> posts = _context.Post.ToList();
            return posts;
        }
        public IActionResult Index()
        {
            List<Post> posts = GetPosts();
            return View(posts);
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
