using EntityFrameworks.Model;
using Repository;
using Service.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class AccountService : IAccountService
    {
        private NewsRepository<Account> repository;
        public AccountService()
        {
            repository = new NewsRepository<Account>();
        }
        public Account AddAccount(Account account)
        {
            return repository.Add(account);
        }

        public bool DeleteAccount(object id)
        {
            repository.Delete(id);
            return true;

        }

        public IEnumerable<Account> GetAll()
        {
            return repository.GetByWhere(x => true);
        }

        public Account GetById(object id)
        {
            return repository.GetById(id);
        }
        public Account GetAccountByJournalist(int user)
        {
            return repository.GetByCondition(x => x.UserId == user);
        }
        public Account UpdateAccount(Account account)
        {
        
        var exits = repository.GetByCondition(x => x.UserId.Equals(account.UserId));
            if (exits != null)
            {
                exits.UserId = account.UserId;
                exits.AccountName = account.AccountName;
                exits.Active = account.Active;
                exits.Password = account.Password;
                repository.Update(exits);
            }
            return exits;
        }
    }
}
