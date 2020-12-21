using System;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Localization { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        public User User { get; set; }
    }
}
