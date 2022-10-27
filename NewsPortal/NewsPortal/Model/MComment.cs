using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Model
{
    public class MComment
    {
        public int Id { get; set; } 
        public string Content { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateOn { get; set; }
        public string UserUsername { get; set; }

    }
}
