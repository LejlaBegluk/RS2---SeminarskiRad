using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Request;
using NewsPortal.Models;
using NewsPortal.Services;
using NewsPortal.WebAPI.Controllers;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;

namespace NewsPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : CRUDController<MArticle, ArticleSearchRequest, ArticleUpsertRequest, ArticleUpsertRequest>
    {
        public ArticleController(ICRUDService<MArticle, ArticleSearchRequest, ArticleUpsertRequest, ArticleUpsertRequest> service) : base(service)
        {

        }
    }
}