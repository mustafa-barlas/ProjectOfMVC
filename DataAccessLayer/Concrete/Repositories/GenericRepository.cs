using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

       // DbSet<T> _object;

       // public GenericRepository(Object _object)
       // {
       //    _object = c.Set<T>();     
       // }

        
        public List<T> GetAllList()
        {
            return c.Set<T>().ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).SingleOrDefault();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();

        }
        public void Insert(T p)
        {
            var  addedEntity = c.Entry(p);
            addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //c.Add(p);
            c.SaveChanges();
        }
        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            c.SaveChanges();
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            // c.Remove(p);
            c.SaveChanges();
        }

    }
}