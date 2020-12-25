using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class StorePoints
    {
        public int Id { get; set; }
        public Store Store { get; set; }
        public User User { get; set; }
        public int Points { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }
    }
}
