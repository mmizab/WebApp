﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
