﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.Request
{
    public class ArticleSearchRequest
    {
        public string Title { get; set; }
        public int UserID { get; set; }
    }
}
