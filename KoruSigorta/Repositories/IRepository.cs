using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rezervasyon.Abstract
{
    public interface IRepository<T>
    {
        T GetByID(object id);
        List<T> List();
        void Insert(T p);
        void Update(T p);
    }
}
