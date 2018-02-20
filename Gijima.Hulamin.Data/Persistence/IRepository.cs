using Gijima.Hulamin.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gijima.Hulamin.Data.Persistence
{
    public interface IRepository
    {
        Task<bool> CreateAsync(IEntity entity);

        Task<List<IEntity>> GetAllAsync();

        Task<int> GetByIdAsync(int id);

        Task<bool> UpdateAsync(IEntity entity);
    }
}
