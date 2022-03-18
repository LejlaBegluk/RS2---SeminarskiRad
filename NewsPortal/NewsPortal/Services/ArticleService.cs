using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using NewsPortal.Model.Request;
using NewsPortal.Models;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article = NewsPortal.WebAPI.Database.Article;

namespace NewsPortal.Services
{
    public class ArticleService : CRUDService<MArticle, ArticleSearchRequest, Article, ArticleUpsertRequest, ArticleUpsertRequest>
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public ArticleService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MArticle>> Get(ArticleSearchRequest request)
        {
            var query = _context.Articles.AsQueryable().OrderBy(c => c.Title);

            if (!string.IsNullOrWhiteSpace(request?.Title))
            {
                query = query.Where(x => x.Title.StartsWith(request.Title)).OrderBy(c => c.Title);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MArticle>>(list);
        }
        public override async Task<MArticle> GetById(int ID)
        {
            var entity = await _context.Articles
                .Where(i => i.Id == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MArticle>(entity);
        }
        public override async Task<MArticle> Insert(ArticleUpsertRequest request)
        {
           var entity = _mapper.Map<Article>(request);
            entity.CreateOn = DateTime.Now;
            _context.Set<Article>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MArticle>(entity);
        }
        public override async Task<MArticle> Update(int ID, ArticleUpsertRequest request)
        {
            var Article = await _context.Articles.FindAsync(ID);
            var entity = _context.Set<Article>().Find(ID);
            entity.UpdatedOn = DateTime.Now;
            _context.Set<Article>().Attach(entity);
            _context.Set<Article>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MArticle>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var Article = await _context.Articles.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (Article != null)
            {
                var articleList = await _context.Articles.Where(i => i.UserId == ID).ToListAsync();

                if (!articleList.Any())
                {
                    _context.Articles.Remove(Article);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}