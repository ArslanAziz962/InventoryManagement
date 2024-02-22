using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected DatabaseContext DatabaseContext { get; set; }
        public RepositoryBase(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }



        public bool Create(T entity)
        {
            try
            {
                DatabaseContext.Add(entity);
                DatabaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public T Delete(T entity)
        {
            try
            {
                DatabaseContext.Remove(entity);
                DatabaseContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                
                return DatabaseContext.Set<T>().AsNoTracking();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return DatabaseContext.Set<T>().Where(expression).AsNoTracking();

        }

        public bool Update(T entity)
        {
            try
            {
                DatabaseContext.Update(entity);
                DatabaseContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
