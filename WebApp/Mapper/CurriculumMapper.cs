using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class CurriculumMapper
    {
        private UserMapper UserMapper = new UserMapper();
        public CurriculumDto CurriculumToDto(Curriculum curriculum) {
            UserDto userdto = UserMapper.UserToDto(curriculum.User);
            CurriculumDto dto = new CurriculumDto { Id = curriculum.Id, Experiencia = curriculum.Experiencia, Formacion = curriculum.Formacion, InfoAdicional = curriculum.InfoAdicional, UserDto = userdto };
            return dto;
        }
    }
}
