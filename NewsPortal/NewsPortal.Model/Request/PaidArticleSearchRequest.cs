using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.Request
{
    public class PaidArticleSearchRequest:BaseSearchObject
    {
        public string Text { get; set; }
        public int UserID { get; set; }
    }
}
