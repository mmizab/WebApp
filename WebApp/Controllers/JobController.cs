using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTO;

namespace WebApp.Controllers
{
    public class JobController : Controller
    {
        [Route("/bolsa")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateJob(JobDto jobDto) {

            return null; 
        }
    }
}
