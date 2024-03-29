﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> expression);
        bool Create(T entity);
        bool Update(T entity);  
        T Delete(T entity);
    }
}
