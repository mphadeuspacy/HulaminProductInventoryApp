using System.Collections.Generic;
using Gijima.Hulamin.Core.Entities;
using System;
using System.Threading.Tasks;
using Gijima.Hulamin.Core.Validation.Abstracts;
using System.Data;
using System.Data.SqlClient;
using Gijima.Hulamin.Core.Exceptions;
using Microsoft.ApplicationBlocks.Data;

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
                if (entity is Product product)
                {
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "CreateProduct",
                        new SqlParameter("@ProductName", product.Name),
                        new SqlParameter("@SupplierID", product.SupplierID),
                        new SqlParameter("@CategoryID", product.CategoryID),
                        new SqlParameter("@QuantityPerUnit", product.QuantityPerUnit),
                        new SqlParameter("@UnitPrice", product.UnitPrice),
                        new SqlParameter("@UnitsInStock", product.UnitsInStock),
                        new SqlParameter("@UnitsOnOrder", product.UnitsOnOrder),
                        new SqlParameter("@ReorderLevel", product.ReorderLevel),
                        new SqlParameter("@Discontinued", product.Discontinued));
                }
                else if (entity is Category category)
                {
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "CreateCategory",
                        new SqlParameter("@CategoryName", category.Name),
                        new SqlParameter("@Description", category.Description),
                        new SqlParameter("@Picture", category.Picture));
                }
                else if (entity is Supplier supplier)
                {
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "CreateSupplier",
                        new SqlParameter("@SupplierName", supplier.Name),
                        new SqlParameter("@ContactName", supplier.ContactName),
                        new SqlParameter("@ContactTitle", supplier.ContactTitle),
                        new SqlParameter("@Address", supplier.Address),
                        new SqlParameter("@City", supplier.City),
                        new SqlParameter("@Region", supplier.Region),
                        new SqlParameter("@PostalCode", supplier.PostalCode),
                        new SqlParameter("@Country", supplier.Country),
                        new SqlParameter("@Phone", supplier.Phone),
                        new SqlParameter("@Fax", supplier.Fax),
                        new SqlParameter("@HomePage", supplier.HomePage));
                }

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
