using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int entityId);
        void Add(T newEntity);
        void Update(T entity);
        void Delete(T entity);
    }
}
