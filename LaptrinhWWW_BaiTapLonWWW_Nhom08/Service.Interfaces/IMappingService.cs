using EntityFrameworks.Model;

namespace Service.Interfaces
{
    public interface IMappingService : IBaseService<Mapping>
    {
        Mapping AddMapping(Mapping mapping);
        bool DeleteMapping(object id);
    }
}
