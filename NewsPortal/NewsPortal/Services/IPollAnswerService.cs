using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.WebAPI.Services
{
    public interface IPollAnswerService
    {
        public Task<int> Vote(int Id);
        public  Task<List<MPollAnswer>> GetByPollId(int ID);
        public  Task<IEnumerable<PollResultsRequest>> Results(int Id);
    }
}
