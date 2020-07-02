using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ITSTask.Repository.Contracts.Base
{
    public interface IRepository<TEntity>: IDisposable where TEntity : class 
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);


        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        string AddOrUpdate(TEntity entity, int? id);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
