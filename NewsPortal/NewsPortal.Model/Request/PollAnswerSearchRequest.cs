using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class PollAnswerSearchRequest : BaseSearchObject
    {
        public int PollId { get; set; }
    }
}
