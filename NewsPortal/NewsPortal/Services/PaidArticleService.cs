using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public class PaidArticleService : CRUDService<MPaidArticle, PaidArticleSearchRequest, PaidArticle, PaidArticleUpsertRequest, PaidArticleUpsertRequest>, IPaidArticleService
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public PaidArticleService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override IEnumerable<MPaidArticle> Get(PaidArticleSearchRequest request)
        {
            var query = _context.PaidArticles.Include(a => a.User).AsQueryable().OrderBy(c => c.CreateOn);

            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Content.StartsWith(request.Text)).OrderBy(c => c.CreateOn);
            }
            else if (request.UserID != 0)
            {
                query = query.Where(x => x.UserId == request.UserID).OrderBy(c => c.CreateOn);
            }
            var list = query.ToList();

            return _mapper.Map<IEnumerable<MPaidArticle>>(list);
        }
        public override MPaidArticle GetById(int ID)
        {
            var entity = _context.PaidArticles
                .Where(i => i.Id == ID)
                .SingleOrDefault();

            return _mapper.Map<MPaidArticle>(entity);
        }
        public override async Task<MPaidArticle> Insert(PaidArticleUpsertRequest request)
        {
            var entity = _mapper.Map<PaidArticle>(request);
            _context.Set<PaidArticle>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MPaidArticle>(entity);
        }
        public override async Task<MPaidArticle> Update(int ID, PaidArticleUpsertRequest request)
        {
            //var Article = await _context.Articles.FindAsync(ID);
            var entity = _context.Set<PaidArticle>().Find(ID);
          //  entity.UpdatedOn = DateTime.Now;
            _context.Set<PaidArticle>().Attach(entity);
            _context.Set<PaidArticle>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MPaidArticle>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var PaidArticle = await _context.PaidArticles.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (PaidArticle != null)
            {
               
                _context.PaidArticles.Remove(PaidArticle);
                await _context.SaveChangesAsync();
                return true;

            }
            return false;
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