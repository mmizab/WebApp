using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class JobController : Controller
    {
        [Route("/bolsa")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
