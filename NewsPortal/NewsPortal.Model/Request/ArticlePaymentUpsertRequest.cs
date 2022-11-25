using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Model.Request
{
    public class ArticlePaymentUpsertRequest
    {
        public double Amount { get; set; }
        public string TansactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }

    }
}
