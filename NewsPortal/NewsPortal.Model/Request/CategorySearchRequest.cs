using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Model.Request
{
    public class CategorySearchRequest : BaseSearchObject
    {
        public string Name { get; set; }
    }

}