using Data_Access_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Repositories
{
    class Repository<T> : IRepository<T> where T: class, IEntity
    {
        private DbContext _context;
        protected DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        virtual public void Create(T item)
        {
            dbSet.Add(item);
        }

        virtual public void Delete(int id)
        {
           dbSet.Remove(dbSet.Find(id));
        }

        virtual public T Get(int id)
        {
            return dbSet.Find(id);
        }

        virtual public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        virtual public void Update(int id, T item)
        {
            var old = dbSet.Find(id);
            dbSet.Remove(old);
            dbSet.Add(item);
        }
    }
}
