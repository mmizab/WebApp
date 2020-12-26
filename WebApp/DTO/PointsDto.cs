using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.DTO
{
    public class PointsDto
    {
        public List<StorePointsDto> StorePoints { get; set; }
        public List<StorePointsHistoryDto> StorePointsHistory { get; set; }
    }
}
