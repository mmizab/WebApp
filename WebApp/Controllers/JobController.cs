using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class JobController : BaseController
    {
        private JobService JobService { get; set; }
        public JobController(WebAppContext context ):base(context)
        {
            JobService = new JobService(context);
        }

        [Route("/bolsa")]
        public IActionResult Index()
        {
            List<JobDto> jobs = JobService.GetJobs();
            return View(jobs);
        }

        [Route("/bolsa/{id}")]
        public IActionResult GetJob(int id) {
            JobDto dto = JobService.GetJob(id);
            return View(dto);
        }

        [HttpPost]
        public IActionResult CreateJob(JobDto jobDto) {
            User user = GetUser();
            JobService.SaveJob(jobDto, user);
            return RedirectToAction("Index"); 
        }
    }
}
