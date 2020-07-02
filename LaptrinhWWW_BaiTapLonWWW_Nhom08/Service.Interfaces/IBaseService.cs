using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IBaseService<T> where T:class
    {
        T GetById(object id);
        IEnumerable<T> GetAll();
    }
}
