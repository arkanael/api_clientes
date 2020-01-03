using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity> : IDisposable
        where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Find();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        TEntity Find(Guid id);
    }
}
