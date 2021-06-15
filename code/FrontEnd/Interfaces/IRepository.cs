using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FrontEnd.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> FinalALL();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);

        T Create(T entity);

        T Update(T entity);

        void Delete(T entity);
    
    }
}
