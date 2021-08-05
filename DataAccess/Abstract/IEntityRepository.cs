using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity:class, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
    }
}
