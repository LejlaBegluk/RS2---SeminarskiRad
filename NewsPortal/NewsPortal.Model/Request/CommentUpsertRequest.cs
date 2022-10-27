using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class CommentUpsertRequest
    {
        [Required]
        public string Content { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }

    }
}
