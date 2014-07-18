using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PixivClone.ServiceLayers
{
    public interface IEntityService<T> where T : class
    {
        void Add(T entity);
    }
}