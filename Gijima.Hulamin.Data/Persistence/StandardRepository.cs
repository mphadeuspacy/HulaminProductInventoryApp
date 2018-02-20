using System.Collections.Generic;
using Gijima.Hulamin.Core.Entities;
using System;
using System.Threading.Tasks;
using Gijima.Hulamin.Core.Validation;

namespace Gijima.Hulamin.Data.Persistence
{
    public class StandardRepository : IRepository
    {
        private string _connectionString;

        public StandardRepository(string connectionString)
        {
            _connectionString = string.IsNullOrWhiteSpace(connectionString) == false ? connectionString : throw new ArgumentException();
        }

        public async Task<bool> CreateAsync(IEntity entity)
        {
            ValidateEntity(entity);            

            return true;
        }

        public async Task<List<IEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        private void ValidateEntity(IEntity entity)
        {
            //ISpecification<IEntity> IdAndNameIsValidSpecification = new OrSpecification<IEntity>(null, null);

            //var validentityValues = IdAndNameIsValidSpecification.Or(new ValidNumberSpecification()).Or(new ValidTextSpecification());

            //IdAndNameIsValidSpecification.Or(new )

            //if (entity == null || entity.Id <= 0 || string.IsNullOrWhiteSpace(entity.Name)) return false;
        }
    }
}
