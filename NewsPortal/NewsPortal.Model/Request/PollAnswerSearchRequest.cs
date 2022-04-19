using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class PollAnswerSearchRequest : BaseSearchObject
    {
        public string Text { get; set; }
    }
}
