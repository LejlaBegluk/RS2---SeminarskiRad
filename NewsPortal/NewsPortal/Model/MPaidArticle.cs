﻿using System;

namespace NewsPortal.WebAPI.Model
{
    public class MPaidArticle
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateOn { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public MUser User { get; set; }
    }
}
