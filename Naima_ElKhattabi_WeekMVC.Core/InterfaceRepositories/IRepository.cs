using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        //CRUD operations
        public List<T> Fetch();
        public T Add(T item);
        public T Update(T item);
        public bool Delete(T item);
    }
}
