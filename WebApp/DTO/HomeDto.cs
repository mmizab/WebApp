using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class HomeDto
    {
        public List<PostDto> PostDto { get; set; }
        public List<CategoryDto> CategoryDto { get; set; }
    }
}
