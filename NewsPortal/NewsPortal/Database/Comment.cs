using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsPortal.WebAPI.Database
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreateOn { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
