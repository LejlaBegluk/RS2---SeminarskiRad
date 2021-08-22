using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Model.Models.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CRUDController<MCategory, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoryController(ICRUDService<MCategory, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest> service) : base(service)
        {

        }
    }
}