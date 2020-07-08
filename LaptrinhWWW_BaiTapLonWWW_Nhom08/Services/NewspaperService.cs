using EntityFrameworks.Model;
using Repository;
using Service.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class NewspaperService : INewspaperService
    {
        private NewsRepository<Newspaper> repository;
        public NewspaperService()
        {
            repository = new NewsRepository<Newspaper>();
        }
        public Newspaper AddNewspaper(Newspaper newspaper)
        {
            return repository.Add(newspaper);
        }

        public bool DeleteNewspaper(object id)
        {
            repository.Delete(id);
            return true;
        }

        public IEnumerable<Newspaper> GetAll()
        {
            return repository.GetByWhere(x => true);
        }

        public Newspaper GetById(object id)
        {
            return repository.GetById(id);
        }

        public Newspaper UpdateNewspaper(Newspaper newspaper)
        {
            var exits = repository.GetByCondition(x => x.NewsId.Equals(newspaper.NewsId));
            if (exits != null)
            {
                exits.PublicationDate = newspaper.PublicationDate;
                exits.Journalist = newspaper.Journalist;
                exits.Description = newspaper.Description;
                exits.Active = newspaper.Active;
                exits.Title = newspaper.Title;
                exits.Image = newspaper.Image;
                repository.Update(exits);
            }
            return exits;
        }
    }
}
