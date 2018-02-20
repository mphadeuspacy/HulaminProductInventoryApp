using System.Collections.Generic;
using Gijima.Hulamin.Core.Entities;
using System;
using System.Threading.Tasks;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Concretes;
using Gijima.Hulamin.Core.Validation.Abstracts;

namespace Gijima.Hulamin.Data.Persistence
{
    public class StandardRepository : IRepository
    {
        private SpecificationHandler SpecificationHandler { get; }
        private string _connectionString;

        public StandardRepository(ISetUpSpecificationHandler specificationHandlerSetUp, string connectionString)
        {
            SpecificationHandler = specificationHandlerSetUp.SetUpChain();
            _connectionString = string.IsNullOrWhiteSpace(connectionString) == false ? connectionString : throw new ArgumentException();
        }

        public async Task CreateAsync(IEntity entity)
        {
            ValidateEntity(entity); 
        }

        public async Task<List<IEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(IEntity entity)
        {
            throw new NotImplementedException();
        }

        private void ValidateEntity(IEntity entity)
        {
            SpecificationHandler.HandleSpecificationRequest(entity);
        }
    }
}
