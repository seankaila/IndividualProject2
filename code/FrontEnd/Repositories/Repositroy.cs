using FrontEnd.Data;
using FrontEnd.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FrontEnd.Repositories
{
    [ExcludeFromCodeCoverage]
    public class Repositroy<T> : IRepository<T> where T : class
    {
        protected ApplicationDBContext RepositoryContext { get; set; }

        public Repositroy(ApplicationDBContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public T Create(T entity)
        {
            return RepositoryContext.Set<T>().Add(entity).Entity;
        }

        public IEnumerable<T> FinalALL()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
    }
}
