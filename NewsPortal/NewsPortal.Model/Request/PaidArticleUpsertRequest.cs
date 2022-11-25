using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.Request
{
    public class PaidArticleUpsertRequest
    {
        public string Content { get; set; }
        public DateTime CreateOn { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public int PaidArticleStatusId { get; set; }
        public string Title { get; set; }   

    }
}
