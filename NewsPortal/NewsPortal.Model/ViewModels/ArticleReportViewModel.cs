using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.ViewModels
{
    public class ArticleReportViewModel
    {
        public string CategoryName { get; set; }
        public string Journalist { get; set; }
        public int CommentNumber { get; set; }
        public string Title { get; set; }
        public int Likes { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
