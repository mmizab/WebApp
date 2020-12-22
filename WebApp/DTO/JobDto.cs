using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Localization { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public UserDto User { get; set; }
    }
}
