using EntityFrameworks.Model;
using Repository;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : IUserService
    {
        private NewsRepository<User> repository;
        public UserService()
        {
            repository = new NewsRepository<User>();
        }
        public User AddUser(User user)
        {
            return repository.Add(user);
        }

        public bool DeleteUser(object id)
        {
            repository.Delete(id);
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetByWhere(x => true);
        }

        public User GetUserById(int id)
        {
            return repository.GetByCondition(x => x.UserId == id);
        }

        public User GetById(object id)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            var exits = repository.GetByCondition(x => x.UserId.Equals(user.UserId));
            if (exits != null)
            {
                exits.UserName = user.UserName;
                exits.Email = user.Email;
                exits.DateOfBirth = user.DateOfBirth;
                exits.Gender = user.Gender;
                exits.Role = user.Role;
                exits.Phone = user.Phone;
                repository.Update(exits);
            }
            return null;
        }
        public IEnumerable<User> ListJournalist(int role)
        {
            return repository.GetByWhere(x => x.Role == role).ToList();
        }
        public User GetJournalist(int id)
        {
            return repository.GetByCondition(x => x.UserId == id);
        }

        public bool DeleteJournalist(int id)
        {
            repository.Delete(id);
            return true;
        }
    }
}
