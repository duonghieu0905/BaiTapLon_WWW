using EntityFrameworks.Model;
using Repository;
using Service.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class MappingService : IMappingService
    {
        private NewsRepository<Mapping> repository;
        public MappingService()
        {
            repository = new NewsRepository<Mapping>();
        }
        public Mapping AddMapping(Mapping mapping)
        {
            return repository.Add(mapping);
        }

        public bool DeleteMapping(object id)
        {
            repository.Delete(id);
            return true;
        }

        public IEnumerable<Mapping> GetAll()
        {
            return repository.GetByWhere(x => true);
        }

        public Mapping GetById(object id)
        {
            return repository.GetById(id);
        }
    }
}
