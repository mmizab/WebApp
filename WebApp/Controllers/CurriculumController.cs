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
    public class CurriculumController : BaseController
    {
        public CurriculumService CurriculumService { get; set; }

        public CurriculumController(WebAppContext context) : base(context)
        {
            CurriculumService = new CurriculumService(context);
        }

        [Route("/curriculum")]
        public IActionResult Index()
        {
            User user = GetUser();
        
            CurriculumDto dto = CurriculumService.GetCurriculum(user);

            return View(dto);
        }

        [HttpPost]
        public IActionResult SaveCurriculum(CurriculumDto dto) {
            
            User user = GetUser();

            CurriculumService.SaveCurriculum(dto, user);

            return RedirectToAction("Index");
        }

        public IActionResult SubmitCurriculum() {
            User user = GetUser();

            return RedirectToAction("Index");
        }
    }
}
