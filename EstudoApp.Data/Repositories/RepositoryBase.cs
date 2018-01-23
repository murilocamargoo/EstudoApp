using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EstudoApp.Data.Context;
using EstudoApp.Domain.Interfaces;

namespace EstudoApp.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        protected EstudoAppContext Db = new EstudoAppContext();

        public virtual void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public virtual TEntity GetById(int? id)
        {
            return Db.Set<TEntity>().AsNoTracking().SingleOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicatExpression)
        {
            IEnumerable<TEntity> results = Db.Set<TEntity>()
                .Where(predicatExpression).ToList();

            return results;
        }

        public virtual void Update(TEntity obj)
        {
            Db.Set<TEntity>().Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public virtual void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }
    }
}
