using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class CommentSearchRequest : BaseSearchObject
    {
        public string Text { get; set; }
        public int ArticleId { get; set; }
    }
}
