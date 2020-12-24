using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Curriculum
    {
        public int Id { get; set; }
        public string Experiencia { get; set; }
        public string Formacion { get; set; }
        public string InfoAdicional { get; set; }
        public User User { get; set; }
    }
}
