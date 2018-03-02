using Gijima.Hulamin.Core.Entities;
using System.Collections.Generic;

namespace Gijima.Hulamin.Data.Persistence
{
    public interface IRepository
    {
        int Create(IEntity entity);

        List<IEntity> GetAll();

        IEntity GetById(int id);

        int Update(IEntity entity);
    }
}
