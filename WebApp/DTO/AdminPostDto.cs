using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class AdminPostDto
    {
        // use this prop to update data of a store
        public int StoreId { get; set; }
        public List<StoreDto> StoreDto { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<CategoryDto> CategoryDto { get; set; }
        public int CategoryId { get; set; }
    }
}
