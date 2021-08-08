﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Models
{
    public class ArticlePhoto
    {
         public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }
        public bool IsMain { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
