using EntityFrameworks.Model;

namespace Service.Interfaces
{
    public interface IAccountService : IBaseService<Account>
    {
        Account AddAccount(Account account);
        Account UpdateAccount(Account account);
        bool DeleteAccount(object id);
    }
}
