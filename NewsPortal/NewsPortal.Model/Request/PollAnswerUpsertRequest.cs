using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class PollAnswerUpsertRequest
    {
        public string Text { get; set; }
        public int PollId { get; set; }
        public int Counter { get; set; }
    }
}
