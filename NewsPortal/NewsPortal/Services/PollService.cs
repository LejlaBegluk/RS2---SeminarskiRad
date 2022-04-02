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
    public class PollService : CRUDService<MPoll, PollSearchRequest, Poll, PollUpsertRequest, PollUpsertRequest>
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public PollService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MPoll>> Get(PollSearchRequest request)
        {
            var query = _context.Polls.AsQueryable().OrderBy(c => c.Question);

            if (!string.IsNullOrWhiteSpace(request?.Question))
            {
                query = query.Where(x => x.Question.StartsWith(request.Question)).OrderBy(c => c.Question);
            } 
            var list = await query.ToListAsync();

            return _mapper.Map<List<MPoll>>(list);
        }
        public override async Task<MPoll> GetById(int ID)
        {
            var entity = await _context.Polls
                .Where(i => i.Id == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MPoll>(entity);
        }
        public override async Task<MPoll> Insert(PollUpsertRequest request)
        {
            if (await _context.Polls.AnyAsync(i => i.Question == request.Question))
            {
                throw new UserException("Poll with that name already exists!");
            }

            var entity = _mapper.Map<Poll>(request);
            _context.Set<Poll>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MPoll>(entity);
        }
        public override async Task<MPoll> Update(int ID, PollUpsertRequest request)
        {
            var poll = await _context.Polls.FindAsync(ID);
            if (await _context.Polls.AnyAsync(i => i.Question == request.Question) && request.Question != poll.Question)
            {
                throw new UserException("Poll with that question already exists!");
            }

            var entity = _context.Set<Poll>().Find(ID);
            _context.Set<Poll>().Attach(entity);
            _context.Set<Poll>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MPoll>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var poll = await _context.Polls.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (poll != null)
            {
                var answerList = await _context.PollAnswer.Where(i => i.PollId == ID).ToListAsync();

                if (!answerList.Any())
                {
                    _context.Polls.Remove(poll);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}