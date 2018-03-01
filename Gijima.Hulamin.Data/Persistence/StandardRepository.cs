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
        private readonly string _connectionString;

        public StandardRepository(ISetUpSpecificationHandler specificationHandlerSetUp, string connectionString)
        {
            SpecificationHandler = specificationHandlerSetUp.SetUpChain();
            _connectionString = string.IsNullOrWhiteSpace(connectionString) == false ? connectionString : throw new ArgumentException();
        }

        public async Task<int> CreateAsync(IEntity entity)
        {
            ValidateEntity(entity);

            try
            {
                if (entity is Category category)
                {
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "CreateCategory",
                        new SqlParameter("@Name", category.Name),
                        new SqlParameter("@Description", category.Description),
                        new SqlParameter("@Picture", category.Picture));
                }
                else if (entity is Supplier supplier)
                {
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "CreateSupplier",
                        new SqlParameter("@Name", supplier.Name),
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
                else if (entity is Product product)
                {                    
                    SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "CreateProduct",
                        new SqlParameter("@Name", product.Name),
                        new SqlParameter("@SupplierId", product.SupplierId),
                        new SqlParameter("@CategoryId", product.CategoryId),
                        new SqlParameter("@QuantityPerUnit", product.QuantityPerUnit),
                        new SqlParameter("@UnitPrice", product.UnitPrice), 
                        new SqlParameter("@UnitsInStock", product.UnitsInStock),                        
                        new SqlParameter("@UnitsOnOrder", product.UnitsOnOrder),
                        new SqlParameter("@ReorderLevel", product.ReorderLevel),
                        new SqlParameter("@Discontinued", product.Discontinued));
                }

            }
            catch (BusinessException sqlException)
            {
                throw new BusinessException(sqlException.Message, LogSeverity.Error);
            }
            catch (SqlException sqlException)
            {
                throw new BusinessException(sqlException.Message, LogSeverity.Fatal);
            }
            catch (Exception exception)
            {
                throw new BusinessException(exception.Message, LogSeverity.Fatal);
            }

            return null;
        }

        public async Task<List<IEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEntity> GetByIdAsync(int id)
        {
            if(id <= 0) return null;

            try
            {
                IDataReader productReader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "GetProductById", new SqlParameter("@Id", id));

                if (productReader.Read())
                {
                    return new Product
                    {
                        Id = (int)productReader[nameof(Product.Id)],
                        Name = productReader[nameof(Product.Name)].ToString(),
                        SupplierId = (int)productReader[nameof(Product.SupplierId)],
                        CategoryId = (int)productReader[nameof(Product.CategoryId)],
                        QuantityPerUnit = productReader[nameof(Product.QuantityPerUnit)].ToString(),
                        UnitPrice = (decimal?)productReader[nameof(Product.UnitPrice)],
                        UnitsInStock = (byte?)productReader[nameof(Product.UnitsInStock)],
                        UnitsOnOrder = (byte?)productReader[nameof(Product.UnitsOnOrder)],
                        ReorderLevel = (byte?)productReader[nameof(Product.ReorderLevel)],
                        Discontinued = (bool?)productReader[nameof(Product.Discontinued)],
                    };
                }
            }
            catch (SqlException sqlException)
            {
                throw new BusinessException(sqlException.Message, LogSeverity.Fatal);
            }

            return null;
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
