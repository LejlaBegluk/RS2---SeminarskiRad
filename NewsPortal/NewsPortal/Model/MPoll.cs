﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Model
{
    public class MPoll
    {
      public int Id { get; set; }
        public string Question { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
    }
}
