using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.Request
{
    public class PaidArticleStatusSearchRequest : BaseSearchObject
    {
        public string Name { get; set; }
    }

}