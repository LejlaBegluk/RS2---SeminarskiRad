using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsPortal.WebAPI.Database
{
    public class PollAnswer
    {
        public int Id { get; set; }
        [Display(Name = "Answer")]
        [Required]
        public string Text { get; set; }
        public int PollId { get; set; }
        public Poll Poll { get; set; }
        public int Counter { get; set; }
    }
}
