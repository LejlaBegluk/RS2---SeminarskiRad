using AutoMapper;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public class ArticlePaymentService : CRUDService<MArticlePayment, ArticlePaymentSearchRequest, ArticlePayment, ArticlePaymentUpsertRequest, ArticlePaymentUpsertRequest>
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;

        public ArticlePaymentService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<MArticlePayment> Get(ArticlePaymentSearchRequest search)
        {
            var query = _context.ArticlePayments.AsQueryable();

            if (search.UserId != 0)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            var list = query.ToList();

            return _mapper.Map<List<MArticlePayment>>(list);
        }

        public override async Task<MArticlePayment> Insert(ArticlePaymentUpsertRequest request)
        {
            var payment = new ArticlePayment()
            {
                Amount = request.Amount,
                TansactionNumber = request.TansactionNumber,
                TransactionDate = request.TransactionDate,
                UserId = request.UserId
            };

            await _context.ArticlePayments.AddAsync(payment);
            var article=_context.PaidArticles.Where(x => x.Id == request.ArticleId).FirstOrDefault();
            if (article != null)
            {
                article.PaidArticleStatusId = (int)NewsPortal.Model.Enums.PaidArticleStatus.Paid;
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.MArticlePayment>(payment);
        }
    }
}