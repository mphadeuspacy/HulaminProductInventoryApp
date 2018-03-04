using Gijima.Hulamin.Core.Entities;
using System.Collections.Generic;

namespace Gijima.Hulamin.Data.Persistence
{
    public interface IRepository<TEntity>
    {
        int Create(IEntity entity);

        List<IEntity> GetAll();

        IEntity GetById<TEntity>(int id);

        int Update(IEntity entity);
    }
}
