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
            Curriculum curriculum = Context.Curriculum.FirstOrDefault(o => o.User == user);
            if (curriculum == null)
            {
                curriculum = new Curriculum { Experiencia = dto.Experiencia, User = user, Formacion = dto.Formacion, InfoAdicional = dto.InfoAdicional };
                Context.Add(curriculum);
                Context.SaveChanges();
            }
            else
            {
                curriculum.Formacion = dto.Formacion;
                curriculum.InfoAdicional = dto.InfoAdicional;
                curriculum.Experiencia = dto.Experiencia;
                Context.Update(curriculum);
                Context.SaveChanges();
            }
        }
    }
}
