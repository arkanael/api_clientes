using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Projeto.Domain.Services
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> repository;

        protected BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Insert(TEntity entity)
        {
            repository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public IEnumerable<TEntity> Find()
        {
            return repository.Find();
        }

        public TEntity Find(Guid id)
        {
            return repository.Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return repository.Find(expression);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
