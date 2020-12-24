using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class CurriculumDto
    {
        public int Id { get; set; }
        public string Experiencia { get; set; }
        public string Formacion { get; set; }
        public string InfoAdicional { get; set; }
        public UserDto UserDto { get; set; }
    }
}
