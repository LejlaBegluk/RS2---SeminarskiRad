using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class PollUpsertRequest
    {

        [Required]
        public string Question { get; set; }
        public bool Active { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public int UserId { get; set; }
    }
}
