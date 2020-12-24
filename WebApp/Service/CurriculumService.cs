using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;

namespace WebApp.Service
{
    public class CurriculumService
    {
        private WebAppContext Context { get; set; }
        private CurriculumMapper CurriculumMapper = new CurriculumMapper();
        public CurriculumService(WebAppContext context)
        {
            Context = context;
        }
        public CurriculumDto GetCurriculum(User user) {
            Curriculum c = Context.Curriculum.FirstOrDefault( o => o.User == user) ?? new Curriculum() { User = user};
            CurriculumDto dto = CurriculumMapper.CurriculumToDto(c); 
            return dto;
        }

        public void SaveCurriculum(CurriculumDto dto, User user) {
            Curriculum c = new Curriculum { Experiencia = dto.Experiencia, User = user, Formacion = dto.Formacion, InfoAdicional = dto.InfoAdicional };
            Context.Add(c);
            Context.SaveChanges();
            if (c.Id == 0)
            {
                throw new Exception("Error saving Curriculum");
            }
        }
    }
}
