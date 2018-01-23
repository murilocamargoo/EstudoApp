using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EstudoApp.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicatExpression);
        void Update(TEntity obj);
        void Save();
        void Remove(TEntity obj);
    }
}
