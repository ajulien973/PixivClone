using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PixivClone.Models
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
    }
}