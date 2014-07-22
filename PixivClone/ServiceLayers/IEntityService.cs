using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PixivClone.ServiceLayers
{
    public interface IEntityService<T> where T : class
    {
        void Add(T entity);
        IQueryable<T> GetAll();
        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entity);
        void Update(T entity);
    }
}