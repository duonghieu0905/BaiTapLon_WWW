using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface INewsRepository<T> : IRepositoryBase<T>
    {
        T GetById(object id);
    }
}
