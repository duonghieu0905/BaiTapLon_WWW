using EntityFrameworks.Model;

namespace Service.Interfaces
{
    public interface ITopicService : IBaseService<Topic>
    {
        Topic AddTopic(Topic topic);
        Topic UpdateTopic(Topic topic);
        bool DeleteTopic(object id);
    }
}
