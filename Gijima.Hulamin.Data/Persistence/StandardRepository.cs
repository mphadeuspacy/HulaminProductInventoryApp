using System.Collections.Generic;
using Gijima.Hulamin.Core.Entities;
using System;
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

        public int Create(IEntity entity)
        {
            ValidateEntity(entity);

            try
            {
                if (entity is Category category)
                {
                    return (int) SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "CreateCategory",
                        new SqlParameter($"@{nameof(Category.Name)}", category.Name),
                        new SqlParameter($"@{nameof(Category.Description)}", category.Description),
                        new SqlParameter($"@{nameof(Category.Picture)}", category.Picture));
                }

                if (entity is Supplier supplier)
                {
                    return (int) SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "CreateSupplier",
                        new SqlParameter($"@{nameof(Supplier.Name)}", supplier.Name),
                        new SqlParameter($"@{nameof(Supplier.ContactName)}", supplier.ContactName),
                        new SqlParameter($"@{nameof(Supplier.ContactTitle)}", supplier.ContactTitle),
                        new SqlParameter($"@{nameof(Supplier.Address)}", supplier.Address),
                        new SqlParameter($"@{nameof(Supplier.City)}", supplier.City),
                        new SqlParameter($"@{nameof(Supplier.Region)}", supplier.Region),
                        new SqlParameter($"@{nameof(Supplier.PostalCode)}", supplier.PostalCode),
                        new SqlParameter($"@{nameof(Supplier.Country)}", supplier.Country),
                        new SqlParameter($"@{nameof(Supplier.Phone)}", supplier.Phone),
                        new SqlParameter($"@{nameof(Supplier.Fax)}", supplier.Fax),
                        new SqlParameter($"@{nameof(Supplier.HomePage)}", supplier.HomePage));
                }

                if (entity is Product product)
                {
                    var tempStore = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "CreateProduct",
                        new SqlParameter($"@{nameof(Product.Name)}", product.Name),
                        new SqlParameter($"@{nameof(Product.SupplierId)}", product.SupplierId),
                        new SqlParameter($"@{nameof(Product.CategoryId)}", product.CategoryId),
                        new SqlParameter($"@{nameof(Product.QuantityPerUnit)}", product.QuantityPerUnit),
                        new SqlParameter($"@{nameof(Product.UnitPrice)}", product.UnitPrice),
                        new SqlParameter($"@{nameof(Product.UnitsInStock)}", product.UnitsInStock),
                        new SqlParameter($"@{nameof(Product.UnitsOnOrder)}", product.UnitsOnOrder),
                        new SqlParameter($"@{nameof(Product.ReorderLevel)}", product.ReorderLevel),
                        new SqlParameter($"@{nameof(Product.Discontinued)}", product.Discontinued),
                        new SqlParameter("@IdentityId", ParameterDirection.Output));

                    return (int) tempStore;
                }

            }
            catch (BusinessException sqlException)
            {
                //Log
                return default;
            }
            catch (SqlException sqlException)
            {
                //Log
                return default;
            }
            catch (Exception exception)
            {
                //Log
                return default;
            }

            return default;
        }

        public List<IEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEntity GetById(int id)
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

        public int Update(IEntity entity)
        {
            throw new NotImplementedException();
        }

        private void ValidateEntity(IEntity entity)
        {
            SpecificationHandler.HandleSpecificationRequest(entity);
        }
    }
}
