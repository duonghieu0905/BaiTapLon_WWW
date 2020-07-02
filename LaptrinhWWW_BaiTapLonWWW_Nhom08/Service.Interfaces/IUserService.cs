using EntityFrameworks.Model;

namespace Service.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User AddUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(object id);
    }
}
