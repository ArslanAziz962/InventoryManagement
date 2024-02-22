using Entities.Models;
using Repository.Context;
using Repository.Interface;
using Repository.Repositories;
using Service.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public abstract class ServiceBase<T>:IService<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;
        public ServiceBase(IRepositoryBase<T> repository) {             
            _repository = repository;
        }

        public bool Create(T entity)
        {
            
            try
            {
                return _repository.Create(entity);                

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
                _repository.Delete(entity);

                return entity;

            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _repository.GetAll().ToList();
                

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            try
            {
                return _repository.GetBy(expression).First();
                

            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public bool Update(T entity)
        {
            try
            {
                return _repository.Update(entity);                

            }
            catch (Exception ex)
            {
                throw;
            }           
        }
    }
}
