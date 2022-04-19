using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class PollSearchRequest : BaseSearchObject
    {
        public string Question { get; set; }
    }
}
