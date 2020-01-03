using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext context;

        public BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<TEntity> Find()
        {
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return context.Set<TEntity>().AsNoTracking().Where(expression);
        }

        public TEntity Find(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
