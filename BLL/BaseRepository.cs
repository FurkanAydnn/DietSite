using DAL;
using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace BLL
{
    public class BaseRepository<T> where T : class
    {
        private DietContext _db = new DietContext();

        public BaseRepository(DietContext db)
        {
            _db = db;
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetOne(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public List<T> Search(Func<T, bool> querry)
        {
            return _db.Set<T>().Where(querry).ToList();
        }

        public IQueryable<T> Queryable()
        {
            return _db.Set<T>().AsQueryable();
        }

        public bool Add(T record)
        {
            try
            {
                _db.Set<T>().Add(record);
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                T willBeDeleted = GetOne(id);
                _db.Set<T>().Remove(willBeDeleted);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(IEntity willBeUpdated)
        {
            try
            {
                T old = GetOne(willBeUpdated.Id);
                _db.Entry(old).CurrentValues.SetValues(willBeUpdated);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
