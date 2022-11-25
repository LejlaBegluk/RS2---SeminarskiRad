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
    public class PollAnswerService : CRUDService<MPollAnswer, PollAnswerSearchRequest, PollAnswer, PollAnswerUpsertRequest, PollAnswerUpsertRequest>, IPollAnswerService
    {
        private readonly PortalDbContext _context;
        private readonly IMapper _mapper;
        public PollAnswerService(PortalDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override IEnumerable<MPollAnswer> Get(PollAnswerSearchRequest request)
        {
            var query = _context.PollAnswer.AsQueryable().OrderBy(c => c.Text);

            if (request.PollId != 0)
            {
                query = (IOrderedQueryable<PollAnswer>)query.Where(x => x.PollId == request.PollId);
            }
            var list =  query.ToList();

            return _mapper.Map<IEnumerable<MPollAnswer>>(list);
        }
        public override MPollAnswer GetById(int ID)
        {
            var entity =  _context.PollAnswer
                .Where(i => i.Id == ID)
                .SingleOrDefault();

            return _mapper.Map<MPollAnswer>(entity);
        }
        public override async Task<MPollAnswer> Insert(PollAnswerUpsertRequest request)
        {
            if (await _context.PollAnswer.AnyAsync(i => i.Text == request.Text))
            {
                throw new UserException("Answer with that name already exists!");
            }

            var entity = _mapper.Map<PollAnswer>(request);

            _context.Set<PollAnswer>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MPollAnswer>(entity);
        }
        public override async Task<MPollAnswer> Update(int ID, PollAnswerUpsertRequest request)
        {
            var poll = await _context.PollAnswer.FindAsync(ID);
            if (await _context.Polls.AnyAsync(i => i.Question == request.Text) && request.Text != poll.Text)
            {
                throw new UserException("Answer with that question already exists!");
            }

            var entity = _context.Set<PollAnswer>().Find(ID);
            _context.Set<PollAnswer>().Attach(entity);
            _context.Set<PollAnswer>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MPollAnswer>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var answer = await _context.PollAnswer.Where(i => i.Id == ID).FirstOrDefaultAsync();
            if (answer != null)
            {
                    _context.PollAnswer.Remove(answer);
                    await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public  async Task<List<MPollAnswer>> GetByPollId(int ID)
        {
            var query = _context.PollAnswer.AsQueryable().OrderBy(c => c.Text);

            if (ID!=0)
            {
                query = query.Where(x => x.PollId==ID).OrderBy(c => c.Text);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MPollAnswer>>(list);
        }

        public async Task<int> Vote(int Answered)
        {
            var answer = _context.PollAnswer.Find(Answered);
            if (answer != null)
            {
                answer.Counter++;
                _context.PollAnswer.Update(answer);
                await _context.SaveChangesAsync();

            }
            return answer.PollId;
        }
        public async Task<IEnumerable<PollResultsRequest>> Results(int Id)
        {
            var answers = _context.PollAnswer.Where(x => x.PollId==Id).ToList();

            return _mapper.Map<IEnumerable<PollResultsRequest>>(answers);
        }
    }
}