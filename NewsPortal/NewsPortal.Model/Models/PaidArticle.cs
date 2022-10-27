using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.Models
{
    public class PaidArticle
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateOn { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
