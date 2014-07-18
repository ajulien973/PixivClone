using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PixivClone.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _dbset;

        public Repository(IDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void DeleteAll(IEnumerable<T> entity)
        {
            foreach (var ent in entity)
            {
                var entry = _context.Entry(ent);
                entry.State = EntityState.Deleted;
                _dbset.Remove(ent);
            }
        }

    }
}