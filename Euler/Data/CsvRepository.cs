using Euler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Euler.Data
{
    public class CsvRepository<T> : IRepository<T> where T : IEntity
    {
        protected readonly List<T> _entities;

        public CsvRepository(IEnumerable<T> entities)
        {
            _entities = entities.ToList();
        }

        public CsvRepository()
        {
            _entities = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(int id)
        {
            return _entities.Where(x => x.Id.Equals(id)).Single();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void Update(T entity)
        {
            var old = GetById(entity.Id);
            old = entity;
        }
    }
}
