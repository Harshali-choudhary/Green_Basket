using green_basket.Server.Entities;

namespace green_basket.Server.Repository.Feedback.Interface
{
    public interface IFeedbackRepository
    {
        Task<List<Feedbacks>> GetAll();
        Task<bool> Insert(Feedbacks feedback);
        Task<bool> Update(Feedbacks feedback);
        Task<bool> Delete(int id);
    }
}
