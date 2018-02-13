using System;
using System.Collections.Generic;
using FiloElasticSearchPoc.Models;

namespace FiloElasticSearchPoc.Repository
{
    public interface IRepository<T> where T:class,IEntity
    {
        bool AddMany(List<T> entities);
        string Add(T entity);
        string Update(T entity);
        string Delete(int id);
        void DeleteAll();

    }
}
