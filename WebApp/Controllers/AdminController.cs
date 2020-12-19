﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Data;
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