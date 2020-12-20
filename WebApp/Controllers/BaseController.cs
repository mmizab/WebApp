using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        public readonly WebAppContext Context;
        public StoreService StoreService { get; set; }
        public CategoryService CategoryService { get; set; }
        public PostService PostService { get; set; }
        public BaseController(WebAppContext context)
        {
            Context = context;
            StoreService = new StoreService(context);
            CategoryService = new CategoryService(context);
            PostService = new PostService(context);
        }
    }
}