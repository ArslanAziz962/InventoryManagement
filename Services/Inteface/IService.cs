
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inteface
{
    public interface IService<T> where T : class
    {
        public bool Create(T entity);
        public bool Update(T entity);
        public T Delete(T entity);
        public IEnumerable<T> GetAll();
        public T GetBy(Expression<Func<T, bool>> expression);
      
    }
}
