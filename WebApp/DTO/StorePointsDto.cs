using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.DTO
{
    public class StorePointsDto
    {
        public List<StorePoints> StorePoints { get; set; }
        public List<StorePointsHistory> StorePointsHistory { get; set; }

    }
}
