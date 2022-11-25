using System;
using System.Collections.Generic;

namespace NewsPortal.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public byte[] Photo { get; set; }
        public byte[] PhotoThumb { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int? PaidArticleId { get; set; }
        public PaidArticle? PaidArticle { get; set; }

    }
}
