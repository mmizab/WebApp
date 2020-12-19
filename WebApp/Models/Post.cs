using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        public Store Store { get; set; }
    }
}
