using ETrade.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core.Service
{
    //Generic Yapi Burada kullanilir.
    public interface IDbService<T> where T : CoreEntity
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        List<T> GetAll();
        T Get(int id);
        bool Save();
       
    }
}
