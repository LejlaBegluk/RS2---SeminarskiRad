using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public class PaidArticleStatusService : CRUDService<MPaidArticleStatus, PaidArticleStatusSearchRequest, PaidArticleStatus, PaidArticleStatusUpsertRequest, PaidArticleStatusUpsertRequest>
    { private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public PaidArticleStatusService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override IEnumerable<MPaidArticleStatus> Get(PaidArticleStatusSearchRequest request)
        {
            var query = _context.PaidArticleStatuses.AsQueryable().OrderBy(c => c.Name);

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name)).OrderBy(c => c.Name);
            }
            var list = query.ToList();

            return _mapper.Map<IEnumerable<MPaidArticleStatus>>(list);
        }
        public override MPaidArticleStatus GetById(int ID)
        {
            var entity = _context.PaidArticleStatuses
                .Where(i => i.Id == ID)
                .SingleOrDefault();

            return _mapper.Map<MPaidArticleStatus>(entity);
        }
        public override async Task<MPaidArticleStatus> Insert(PaidArticleStatusUpsertRequest request)
        {
            if (await _context.PaidArticleStatuses.AnyAsync(i => i.Name == request.Name))
            {
                throw new UserException("PaidArticleStatus with that name already exists!");
            }

            var entity = _mapper.Map<PaidArticleStatus>(request);
            _context.Set<PaidArticleStatus>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MPaidArticleStatus>(entity);
        }
        public override async Task<MPaidArticleStatus> Update(int ID, PaidArticleStatusUpsertRequest request)
        {
            var PaidArticleStatus = await _context.PaidArticleStatuses.FindAsync(ID);
            if (await _context.PaidArticleStatuses.AnyAsync(i => i.Name == request.Name) && request.Name != PaidArticleStatus.Name)
            {
                throw new UserException("PaidArticleStatus with that name already exists!");
            }

            var entity = _context.Set<PaidArticleStatus>().Find(ID);
            _context.Set<PaidArticleStatus>().Attach(entity);
            _context.Set<PaidArticleStatus>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MPaidArticleStatus>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var PaidArticleStatus = await _context.PaidArticleStatuses.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (PaidArticleStatus != null)
            {
                var articleList = await _context.PaidArticles.Where(i => i.PaidArticleStatusId == ID).ToListAsync();

                if (!articleList.Any())
                {
                    _context.PaidArticleStatuses.Remove(PaidArticleStatus);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}