using System;

namespace NewsPortal.WebAPI.Model
{
    public class MArticlePayment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string TansactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
    }
}
