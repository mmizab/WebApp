using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class StorePointsHistory
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public int Points { get; set; }
        public StorePoints StorePoints { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
    }
}
