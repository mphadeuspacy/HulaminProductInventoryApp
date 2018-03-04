using Gijima.Hulamin.Core.Entities;
using System.Collections.Generic;

namespace Gijima.Hulamin.Data.Persistence
{
    public interface IRepository<TEntity>
    {
        int Create(IEntity entity);

        List<IEntity> GetAll<TEntity>();

        IEntity GetById<TEntity>(int id);

        int Update(IEntity entity);

        int Delete<TEntity>(int id);
    }
}
