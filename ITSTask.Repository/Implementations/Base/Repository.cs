using ITSTask.DB;
using ITSTask.Repository.Contracts.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ITSTask.Repository.Implementations.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DataContext _Context;
        
        public Repository(DataContext Context)
        {
            _Context = Context;

        }

        public TEntity Get(int id)
        {
            var data = _Context.Set<TEntity>().Find(id);
            return data;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().AsNoTracking();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public string AddOrUpdate(TEntity entity, int? id)
        {
            string status = "";
            try
            {
                if (id != null & id > 0)
                {
                    _Context.Entry(entity).State = EntityState.Modified;
                    Commit();
                    return status = "Updated";
                }
                else
                {
                    _Context.Set<TEntity>().Add(entity);
                    _Context.Entry(entity).State = EntityState.Added;
                    Commit();
                    return status = "Added";
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex.InnerException;
            }
            catch (DbUpdateException ex)
            {
                throw ex.InnerException;
            }

            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().AddRangeAsync(entities);
                Commit();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex.InnerException;
            }
            catch (DbUpdateException ex)
            {
                throw ex.InnerException;
            }

            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void Remove(int id)
        {
            try
            {
                var entity = _Context.Set<TEntity>().Find(id);
                if (entity != null)
                {
                    _Context.Set<TEntity>().Remove(entity);
                    Commit();
                }               
                
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex.InnerException;
            }
            catch (DbUpdateException ex)
            {
                throw ex.InnerException;
            }

            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().RemoveRange(entities);
                Commit();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex.InnerException;
            }
            catch (DbUpdateException ex)
            {
                throw ex.InnerException;
            }

            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        
        public void Commit()
        {
            // Save changes with the default options
            try
            {
                _Context.SaveChanges();
            }
            catch (DbUpdateException e)
            {               

                throw e.InnerException; 
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
       
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_Context != null)
                {
                    _Context.Dispose();
                    _Context = null;
                }
            }
        }
    }
}
