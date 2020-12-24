using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public List<StoreDto> StoresDto { get; set; }
        public StoreDto StoreDto { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryDto CategoryDto { get; set; }
        public int CategoryId { get; set; }
        public byte[] QrCode { get; set; }
    }
}
