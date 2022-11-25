using System;

namespace NewsPortal.WebAPI.Database
{
    public class PaidArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime CreateOn { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PaidArticleStatusId { get; set; }
        public PaidArticleStatus PaidArticleStatus { get; set; }
    }
}
