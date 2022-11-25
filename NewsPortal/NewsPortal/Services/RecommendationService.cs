using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsPortal.WebAPI.Services
{
    public class RecommendationService : CRUDService<MArticle, RecommendationArticleSearchRequest, Article, RecommendationArticleUpsertRequest, RecommendationArticleUpsertRequest>
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;

        public RecommendationService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override MArticle GetById(int ID)
        {
            var entity = _context.Articles
                .Where(i => i.Id == ID)
                .FirstOrDefault();
            if (entity == null)
                return null;
            var recommended=_context.Articles.Include(a => a.User).Where(i => i.CategoryId == entity.CategoryId && i.Id!=entity.Id).OrderBy(a=> EF.Functions.Random()).FirstOrDefault();
            return _mapper.Map<MArticle>(recommended);
        }
    }
}