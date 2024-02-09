using ETrade.Core.Entity;
using ETrade.Core.Service;
using ETrade.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Service.DbService
{
    public class CoreDbService<T> : IDbService<T> where T : CoreEntity
    {
        private readonly ETradeContext _db;
        public CoreDbService(ETradeContext db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
                Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int id)  => _db.Set<T>().Find(id) ??  throw new Exception("Kayit bulunamadi");
        

        public T Get(int id)
        {
            try
            {
                var a = _db.Set<T>().Find(id);
                return a;
            }
            catch (Exception)
            {
                //return T.Null;
                throw;
            }
        }

        public List<T> GetAll() => _db.Set<T>().ToList();
        

        public bool Remove(T entity)
        {
            try
            {
                _db.Set<T>().Remove(entity);
                Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool Save() => _db.SaveChanges()>0 ? true: false;

        public bool Update(T entity)
        {
            try
            {
                _db.Set<T>().Update(entity);
                return _db.SaveChanges() >0 ? true : false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        
    }
}
