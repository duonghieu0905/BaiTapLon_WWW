using EntityFrameworks.Model;

namespace Service.Interfaces
{
    public interface IFeedbackService : IBaseService<Feedback>
    {
        Feedback AddFeedback(Feedback feedback);
        Feedback UpdateFeedback(Feedback feedback);
        bool DeleteFeedback(object id);
    }
}
