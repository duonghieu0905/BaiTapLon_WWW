using EntityFrameworks.Model;
using Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FeedbackService : IFeedbackService
    {
        private NewsRepository<Feedback> repository;
        public FeedbackService()
        {
            repository = new NewsRepository<Feedback>();
        }
        public Feedback AddFeedback(Feedback feedback)
        {
            return repository.Add(feedback);
        }

        public bool DeleteFeedback(object id)
        {
            repository.Delete(id);
            return true;
        }

        public IEnumerable<Feedback> GetAll()
        {
            return repository.GetByWhere(x => true);

        }

        public Feedback GetById(object id)
        {
            return repository.GetById(id);
        }

        public Feedback UpdateFeedback(Feedback feedback)
        {
            var exits = repository.GetByCondition(x => x.FeedbackId.Equals(feedback.FeedbackId));
            if (exits != null)
            {
                exits.Email = feedback.Email;
                exits.Time = feedback.Time;
                exits.Description = feedback.Description;
                exits.AccountId = feedback.AccountId;
                repository.Update(exits);
            }
            return null;
        }
    }
}
