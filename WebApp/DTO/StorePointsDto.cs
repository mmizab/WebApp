﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class StorePointsDto
    {
        public int Id { get; set; }
        public StoreDto Store { get; set; }
        public UserDto User { get; set; }
        public int Points { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
