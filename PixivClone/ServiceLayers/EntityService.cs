using PixivClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PixivClone.ServiceLayers
{
    public class EntityService<T> where T : class
    {
        private IRepository<T> _repo;

        public EntityService(IRepository<T> repo)
        {
            _repo = repo;
        }

        void Add(T entity)
        {
            _repo.Add(entity);
        }
    }
}