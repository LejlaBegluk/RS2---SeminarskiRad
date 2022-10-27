using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public class CommentService : CRUDService<MComment, CommentSearchRequest, Comment, CommentUpsertRequest, CommentUpsertRequest>, ICommentService
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public CommentService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override  IEnumerable<MComment> Get(CommentSearchRequest request)
        {
            var query = _context.Comments.Include(c=>c.User).AsQueryable().OrderBy(c => c.Content);


             if (request.Id != 0)
            {
                query = query.Where(x => x.ArticleId == request.Id).OrderBy(c => c.CreateOn);
            }
            var list =  query.ToList();

            return _mapper.Map<IEnumerable<MComment>>(list);
        }
        public override MComment GetById(int ID)
        {
            var entity =  _context.Comments
                .Where(i => i.Id == ID)
                .SingleOrDefault();

            return _mapper.Map<MComment>(entity);
        }
        public override async Task<MComment> Insert(CommentUpsertRequest request)
        {
            var entity = _mapper.Map<Comment>(request);
            entity.CreateOn = DateTime.Now;
            _context.Set<Comment>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MComment>(entity);
        }
        public override async Task<MComment> Update(int ID, CommentUpsertRequest request)
        {
            var Comment = await _context.Comments.FindAsync(ID);

            var entity = _context.Set<Comment>().Find(ID);
            
            _context.Set<Comment>().Attach(entity);
            _context.Set<Comment>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MComment>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var Comment = await _context.Comments.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (Comment != null)
            {

                    _context.Comments.Remove(Comment);
                    await _context.SaveChangesAsync();
                    return true;
   
            }
            return false;
        }
        public   List<MComment> GetByArticleId(int ID)
        {
            var entity =  _context.Comments
                .Where(i => i.ArticleId == ID)
                .ToList();

            return _mapper.Map<List<MComment>>(entity);
        }
    }
}