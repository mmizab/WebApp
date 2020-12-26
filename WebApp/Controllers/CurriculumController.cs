using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    [Authorize]
    public class CurriculumController : BaseController
    {
        public CurriculumService CurriculumService { get; set; }
        public MailService MailService = new MailService();

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

        public IActionResult SubmitCurriculum(int jobId) {
            User user = GetUser();
            CurriculumDto dto = CurriculumService.GetCurriculum(user);

            try
            {
                //MailService.SendMail("Experiencia: \n" + dto.Experiencia + "\n" + "Formacion: \n" + dto.Formacion + "\n" + "Informacion adicional: \n" + dto.InfoAdicional);
            }
            catch (Exception)
            {
                throw;
            }
            
            return RedirectToAction("Index");
        }
    }
}
