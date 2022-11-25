using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.Request
{
    public class PaidArticleStatusUpsertRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
