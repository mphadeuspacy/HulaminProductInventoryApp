using Gijima.Hulamin.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gijima.Hulamin.Data.Persistence
{
    public interface IRepository
    {
        Task<int> CreateAsync(IEntity entity);

        Task<List<IEntity>> GetAllAsync();

        Task<IEntity> GetByIdAsync(int id);

        Task UpdateAsync(IEntity entity);
    }
}
