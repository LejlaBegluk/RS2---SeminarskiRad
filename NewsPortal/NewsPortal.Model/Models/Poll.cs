using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsPortal.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool Active { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public  ICollection<PollAnswer> PollAnswers { get; set; }

    }
}
