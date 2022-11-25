using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models
{
    public class ArticlePayment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string TansactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
