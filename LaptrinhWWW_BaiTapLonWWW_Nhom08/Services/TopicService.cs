using EntityFrameworks.Model;
using Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class TopicService : ITopicService
    {
        private NewsRepository<Topic> repository;
        public TopicService()
        {
            repository = new NewsRepository<Topic>();
        }
        public Topic AddTopic(Topic topic)
        {
            return repository.Add(topic);
        }

        public bool DeleteTopic(object id)
        {
            repository.Delete(id);
            return true;
        }

        public IEnumerable<Topic> GetAll()
        {
            return repository.GetByWhere(x => true);
        }

        public Topic GetById(object id)
        {
            return repository.GetById(id);
        }

        public Topic UpdateTopic(Topic topic)
        {
            var exits = repository.GetByCondition(x => x.TopicId.Equals(topic.TopicId));
            if (exits != null)
            {
                exits.TopicName = topic.TopicName;
                repository.Update(exits);
            }
            return null;
        }
    }
}
