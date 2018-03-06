using System.Collections.Generic;
using Gijima.Hulamin.Core.Entities;

namespace Gijima.Hulamin.Core.Persistence
{
    public interface IRepository
    {
        int Create(IEntity entity);

        List<IEntity> GetAll<TEntity>();

        IEntity GetById<TEntity>(int id);

        int Update(IEntity entity);

        int Delete<TEntity>(int id);
    }
}
