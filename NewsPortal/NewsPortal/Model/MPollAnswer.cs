using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Model
{
    public class MPollAnswer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PollId { get; set; }
        public int Counter { get; set; }

    }   
}
