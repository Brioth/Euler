using Euler.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Euler.Data
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
