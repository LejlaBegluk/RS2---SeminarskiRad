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
    public class ArticleService : CRUDService<MArticle, ArticleSearchRequest, Article, ArticleUpsertRequest, ArticleUpsertRequest>, IArticleService
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public ArticleService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override IEnumerable<MArticle> Get(ArticleSearchRequest request)
        {
            var query = _context.Articles.Include(a=>a.User).Include(a=>a.Category).AsQueryable().OrderBy(c => c.Title);

            if (!string.IsNullOrWhiteSpace(request?.Title))
            {
                query = query.Where(x => x.Title.StartsWith(request.Title)).OrderBy(c => c.CreateOn);
            }
            else if (request.UserID != 0)
            {
                query = query.Where(x => x.UserId==request.UserID).OrderBy(c => c.CreateOn);
            }
            else if (request.CategoryID != 0)
            {
                query = query.Where(x => x.CategoryId == request.CategoryID).OrderBy(c => c.CreateOn);
            }
            var list =  query.ToList();

            return _mapper.Map<IEnumerable<MArticle>>(list);
        }
        public override MArticle GetById(int ID)
        {
            var entity =  _context.Articles
                .Where(i => i.Id == ID)
                .SingleOrDefault();

            return _mapper.Map<MArticle>(entity);
        }
        public override async Task<MArticle> Insert(ArticleUpsertRequest request)
        {
           var entity = _mapper.Map<Article>(request);
            _context.Set<Article>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MArticle>(entity);
        }
        public override async Task<MArticle> Update(int ID, ArticleUpsertRequest request)
        {
            //var Article = await _context.Articles.FindAsync(ID);
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
                var CommentList = await _context.Comments.Where(i => i.ArticleId == ID).ToListAsync();
                if (CommentList.Any())
                {
                    foreach(var item in CommentList)
                    {
                        _context.Comments.Remove(item);
                    }
                    _context.SaveChanges();
                }
               _context.Articles.Remove(Article);
               await _context.SaveChangesAsync();
               return true;
               
            }
            return false;
        }
        public override IQueryable<Article> AddFilter(IQueryable<Article> query, ArticleSearchRequest search )
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Title))
            {
                filteredQuery = filteredQuery.Where(x => x.Title.Contains(search.Title));
            }
            return filteredQuery;
        }

        public MArticle LikeArticle(int Id)
        {
            if (Id > 0)
            {
                Article article = _context.Articles.Where(i => i.Id == Id).SingleOrDefault();
                if (article != null)
                {
                    article.Likes++;
                    _context.Set<Article>().Attach(article);
                    _context.Set<Article>().Update(article);
                    _context.SaveChangesAsync();
                    return _mapper.Map<MArticle>(article);
                }
            }
            return null;
        }
    }
}