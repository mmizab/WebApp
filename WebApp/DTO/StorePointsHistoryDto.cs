using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class StorePointsHistoryDto
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public int Points { get; set; }
        public StorePointsDto StorePoints { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
