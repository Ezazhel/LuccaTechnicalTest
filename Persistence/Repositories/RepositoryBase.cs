using Lucca.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected RepositoryDbContext RepositoryDbContext { get; set; }

        protected RepositoryBase(RepositoryDbContext repositoryDbContext)
        {
            RepositoryDbContext = repositoryDbContext;
        }

        public IQueryable<TEntity> FindAll() => RepositoryDbContext.Set<TEntity>().AsNoTracking();

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression) => RepositoryDbContext.Set<TEntity>().Where(expression).AsNoTracking();

        public void Insert(TEntity entity) => RepositoryDbContext.Set<TEntity>().Add(entity);

        public void Update(TEntity entity) => RepositoryDbContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => RepositoryDbContext.Set<TEntity>().Remove(entity);
    }
}