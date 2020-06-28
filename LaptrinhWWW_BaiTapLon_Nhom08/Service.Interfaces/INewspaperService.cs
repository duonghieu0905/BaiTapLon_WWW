using EntityFrameworks.Model;

namespace Service.Interfaces
{
    public interface INewspaperService : IBaseService<Newspaper>
    {
        Newspaper AddNewspaper(Newspaper newspaper);
        Newspaper UpdateNewspaper(Newspaper newspaper);
        bool DeleteNewspaper(object id);
    }
}
