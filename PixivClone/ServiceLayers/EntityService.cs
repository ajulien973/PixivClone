using PixivClone.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PixivClone.ServiceLayers
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        private IRepository<T> _repo;

        public EntityService(IRepository<T> repo)
        {
            _repo = repo;
        }

        public void Add(T entity)
        {
            _repo.Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _repo.GetAll();
        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
        }

        public void DeleteAll(IEnumerable<T> entity)
        {
            _repo.DeleteAll(entity);
        }

        public void Update(T entity)
        {
           _repo.Update(entity);
        }
    }
}