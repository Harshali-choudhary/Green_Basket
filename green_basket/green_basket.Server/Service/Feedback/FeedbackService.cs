using green_basket.Server.Entities;
using green_basket.Server.Repository.Feedback.Interface;

namespace green_basket.Server.Service.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repo;
        public FeedbackService(IFeedbackRepository repo) 
        {
           _repo = repo;
        }
        public async Task<List<Feedbacks>> GetAll()=>await _repo.GetAll();
        public async Task<bool> Insert(Feedbacks feedbacks)=>await _repo.Insert(feedbacks);
        public async Task<bool> Update(Feedbacks feedbacks)=>await _repo.Update(feedbacks);
        public async Task<bool> Delete(int id)=>await _repo.Delete(id);
    }
}
