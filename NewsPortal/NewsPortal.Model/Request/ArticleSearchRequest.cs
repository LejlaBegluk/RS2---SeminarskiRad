﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.Request
{
    public class ArticleSearchRequest : BaseSearchObject
    {
        public string Title { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }

    }
}
