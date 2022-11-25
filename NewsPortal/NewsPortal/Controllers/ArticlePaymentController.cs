using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;

namespace NewsPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlePaymentController : CRUDController<MArticlePayment, ArticlePaymentSearchRequest, ArticlePaymentUpsertRequest, ArticlePaymentUpsertRequest>
    {
        public ArticlePaymentController(ICRUDService<MArticlePayment, ArticlePaymentSearchRequest, ArticlePaymentUpsertRequest, ArticlePaymentUpsertRequest> service) : base(service)
        {
        }
    }
} 