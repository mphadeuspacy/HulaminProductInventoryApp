using System.Collections.Generic;
using Gijima.Hulamin.Core.Entities;
using System;
using System.Threading.Tasks;
using Gijima.Hulamin.Core.Validation.Abstracts;
using System.Data;
using System.Data.SqlClient;
using Gijima.Hulamin.Core.Exceptions;

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

            var sqlConnection = new SqlConnection(_connectionString);

            try
            {                
                sqlConnection.Open();

                var command = sqlConnection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateEntity";
                
                command.Parameters.Add(new SqlParameter(nameof(entity.Name), entity.Name));

                command.BeginExecuteNonQuery();                
            }
            catch (Exception sqlException)
            {
                throw new BusinessException(sqlException.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
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
