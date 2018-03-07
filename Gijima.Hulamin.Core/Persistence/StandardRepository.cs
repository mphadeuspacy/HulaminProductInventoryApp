using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Abstracts;
using Gijima.Hulamin.Core.Validation.Concretes;
using Microsoft.ApplicationBlocks.Data;

namespace Gijima.Hulamin.Core.Persistence
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
            try
            {
                switch (entity)
                {
                    case Category category:
                    {
                        if (new EntityNameRequiredSpecification<Category>().IsSatisfiedBy(category) == false) throw new BusinessException($"{nameof(Create)}: '{nameof(category)}' category name is required!'");

                        if (category.Id != default && GetById<Category>(category.Id) != null) throw new BusinessException($"'{nameof(Category)}' {nameof(category.Name)} already exists!");

                        var insertedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "CreateCategory",
                            new SqlParameter($"@{nameof(Category.Name)}", category.Name),
                            new SqlParameter($"@{nameof(Category.Description)}", category.Description),
                            new SqlParameter($"@{nameof(Category.Picture)}", category.Picture));

                        return int.Parse(insertedRowId.ToString());
                    }
                    case Supplier supplier:
                    {
                        if(new EntityNameRequiredSpecification<Supplier>().IsSatisfiedBy(supplier) == false) throw new BusinessException($"{nameof(Create)}: '{nameof(supplier)}' company name is required!'");

                        if (supplier.Id != default && GetById<Supplier>(supplier.Id) != null) throw new BusinessException($"'{nameof(Supplier)}' {nameof(supplier.Name)} already exists!");

                        var insertedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "CreateSupplier",
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

                        return int.Parse(insertedRowId.ToString());
                    }
                    case Product product:
                    {
                        if (new EntityNameRequiredSpecification<Product>().IsSatisfiedBy(product) == false) throw new BusinessException($"{nameof(Create)}: '{nameof(product)}' product name is required!'");

                        if (product.Id != default && GetById<Product>(product.Id) != null) throw new BusinessException($"'{nameof(Product)}' {nameof(product.Name)} already exists!");

                        var insertedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "CreateProduct",
                            new SqlParameter($"@{nameof(Product.Name)}", product.Name),
                            new SqlParameter($"@{nameof(Product.SupplierId)}", product.SupplierId),
                            new SqlParameter($"@{nameof(Product.CategoryId)}", product.CategoryId),
                            new SqlParameter($"@{nameof(Product.QuantityPerUnit)}", product.QuantityPerUnit),
                            new SqlParameter($"@{nameof(Product.UnitPrice)}", product.UnitPrice),
                            new SqlParameter($"@{nameof(Product.UnitsInStock)}", product.UnitsInStock),
                            new SqlParameter($"@{nameof(Product.UnitsOnOrder)}", product.UnitsOnOrder),
                            new SqlParameter($"@{nameof(Product.ReorderLevel)}", product.ReorderLevel),
                            new SqlParameter($"@{nameof(Product.Discontinued)}", product.Discontinued));

                        return int.Parse(insertedRowId.ToString());
                    }
                }
            }
            catch (BusinessException)
            {
                //Log
                return default;
            }
            catch (SqlException)
            {
                //Log
                return default;
            }
            catch (Exception)
            {
                //Log
                return default;
            }

            return default;
        }

        public List<IEntity> GetAll<TEntity>()
        {
            var entityList = new List<IEntity>();

            try
            {
                IDataReader reader;                

                if (typeof(TEntity) == typeof(Product))
                {
                    reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "GetAllProducts");

                    while (reader.Read())
                    {
                        entityList.Add
                        (
                            new Product
                            {
                                Id = (int)reader["ProductID"],
                                Name = reader["ProductName"].ToString(),
                                SupplierId = string.IsNullOrWhiteSpace(reader["SupplierID"].ToString()) ? 0 : int.Parse(reader["SupplierID"].ToString()),
                                CategoryId = string.IsNullOrWhiteSpace(reader["CategoryID"].ToString()) ? 0 : int.Parse(reader["CategoryID"].ToString()),
                                QuantityPerUnit = reader["QuantityPerUnit"].ToString(),
                                UnitPrice = string.IsNullOrWhiteSpace(reader["UnitPrice"].ToString()) ? 0 : decimal.Parse(reader["UnitPrice"].ToString()),
                                UnitsInStock = string.IsNullOrWhiteSpace(reader["UnitsInStock"].ToString()) ? (short)0 : short.Parse(reader["UnitsInStock"].ToString()),
                                UnitsOnOrder = string.IsNullOrWhiteSpace(reader["UnitsOnOrder"].ToString()) ? (short)0 : short.Parse(reader["UnitsOnOrder"].ToString()),
                                ReorderLevel = string.IsNullOrWhiteSpace(reader["ReorderLevel"].ToString()) ? (short)0 : short.Parse(reader["ReorderLevel"].ToString()),
                                Discontinued = string.IsNullOrWhiteSpace(reader["Discontinued"].ToString()) ? null : (bool?)bool.Parse(reader["Discontinued"].ToString())
                            }
                        );
                    }
                }

                if (typeof(TEntity) == typeof(Supplier))
                {
                    reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "GetAllSuppliers");

                    while (reader.Read())
                    {
                        entityList.Add
                        (
                            new Supplier
                            {
                                Id = (int)reader["SupplierID"],
                                Name = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                ContactTitle = reader["ContactTitle"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Region = reader["Region"].ToString(),
                                PostalCode = reader["PostalCode"].ToString(),
                                Country = reader["Country"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Fax = reader["Fax"].ToString(),
                                HomePage = reader["HomePage"].ToString()
                            }
                        );
                    }
                }

                if (typeof(TEntity) == typeof(Category))
                {
                    reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "GetAllCategories");

                    while (reader.Read())
                    {
                        entityList.Add
                        (
                            new Category
                            {
                                Id = (int)reader["CategoryID"],
                                Name = reader["CategoryName"].ToString(),
                                Description = reader["Description"].ToString(),
                                Picture = Encoding.ASCII.GetBytes(reader["Picture"].ToString())
                            }
                        );
                    }
                }
            }
            catch (BusinessException)
            {
                //Log
                return default;
            }
            catch (SqlException)
            {
                //Log
                return default;
            }
            catch (Exception)
            {
                //Log
                return default;
            }

            return entityList;
        }

        public IEntity GetById<TEntity>(int id)
        {
            if(id <= 0) throw new BusinessException();

            try
            {
                IDataReader reader;

                if (typeof(TEntity) == typeof(Product))
                {
                    reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "GetProductById", new SqlParameter("@Id", id));

                    if (reader.Read())
                    {
                        return new Product
                        {
                            Id = (int)reader["ProductID"],
                            Name = reader["ProductName"].ToString(),
                            SupplierId = string.IsNullOrWhiteSpace(reader["SupplierID"].ToString()) ? 0 : int.Parse(reader["SupplierID"].ToString()),
                            CategoryId = string.IsNullOrWhiteSpace(reader["CategoryID"].ToString()) ? 0 : int.Parse(reader["CategoryID"].ToString()),
                            QuantityPerUnit = reader["QuantityPerUnit"].ToString(),
                            UnitPrice = string.IsNullOrWhiteSpace(reader["UnitPrice"].ToString()) ? 0 : decimal.Parse(reader["UnitPrice"].ToString()),
                            UnitsInStock = string.IsNullOrWhiteSpace(reader["UnitsInStock"].ToString()) ? (short)0 : short.Parse(reader["UnitsInStock"].ToString()),
                            UnitsOnOrder = string.IsNullOrWhiteSpace(reader["UnitsOnOrder"].ToString()) ? (short)0 : short.Parse(reader["UnitsOnOrder"].ToString()),
                            ReorderLevel = string.IsNullOrWhiteSpace(reader["ReorderLevel"].ToString()) ? (short)0 : short.Parse(reader["ReorderLevel"].ToString()),
                            Discontinued = string.IsNullOrWhiteSpace(reader["Discontinued"].ToString()) ? null : (bool?)bool.Parse(reader["Discontinued"].ToString())
                        };
                    }
                }

                if (typeof(TEntity) == typeof(Supplier))
                {
                    reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "GetSupplierById", new SqlParameter("@Id", id));

                    if (reader.Read())
                    {
                        return new Supplier
                        {
                            Id = (int)reader["SupplierID"],
                            Name = reader["CompanyName"].ToString(),
                            ContactName = reader["ContactName"].ToString(),
                            ContactTitle = reader["ContactTitle"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Region = reader["Region"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            Country = reader["Country"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Fax =reader["Fax"].ToString(),
                            HomePage = reader["HomePage"].ToString()
                        };
                    }
                }

                if (typeof(TEntity) == typeof(Category))
                {
                    reader = SqlHelper.ExecuteReader(_connectionString, CommandType.StoredProcedure, "GetCategoryById", new SqlParameter("@Id", id));

                    if (reader.Read())
                    {
                        return new Category
                        {
                            Id = (int)reader["CategoryID"],
                            Name = reader["CategoryName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Picture = Encoding.ASCII.GetBytes(reader["Picture"].ToString())
                        };
                    }
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
            try
            {
                ValidateEntity(entity);

                switch (entity)
                {
                    case Product product:
                    {
                        if (GetById<Product>(product.Id) == null) throw new BusinessException($"'{nameof(Product)}' {nameof(product.Name)} does not already exists!");

                        var updatedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "UpdateProduct",
                            new SqlParameter($"@{nameof(Product.Name)}", product.Name),
                            new SqlParameter($"@{nameof(Product.SupplierId)}", product.SupplierId),
                            new SqlParameter($"@{nameof(Product.CategoryId)}", product.CategoryId),
                            new SqlParameter($"@{nameof(Product.QuantityPerUnit)}", product.QuantityPerUnit),
                            new SqlParameter($"@{nameof(Product.UnitPrice)}", product.UnitPrice),
                            new SqlParameter($"@{nameof(Product.UnitsInStock)}", product.UnitsInStock),
                            new SqlParameter($"@{nameof(Product.UnitsOnOrder)}", product.UnitsOnOrder),
                            new SqlParameter($"@{nameof(Product.ReorderLevel)}", product.ReorderLevel),
                            new SqlParameter($"@{nameof(Product.Discontinued)}", product.Discontinued),
                            new SqlParameter($"@{nameof(Product.Id)}", product.Id));

                        return int.Parse(updatedRowId.ToString());
                    }
                    case Supplier supplier:
                    {
                        if (GetById<Supplier>(supplier.Id) == null) throw new BusinessException($"'{nameof(Supplier)}' {nameof(supplier.Name)} does not already exists!");

                        var updatedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "UpdateSupplier",
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
                            new SqlParameter($"@{nameof(Supplier.HomePage)}", supplier.HomePage),
                            new SqlParameter($"@{nameof(Supplier.Id)}", supplier.Id));

                        return int.Parse(updatedRowId.ToString());
                    }
                    case Category category:
                    {
                        if (GetById<Category>(category.Id) == null) throw new BusinessException($"'{nameof(Category)}' {nameof(category.Name)} does not already exists!");

                        var updatedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "UpdateCategory",
                            new SqlParameter($"@{nameof(Category.Name)}", category.Name),
                            new SqlParameter($"@{nameof(Category.Description)}", category.Description),
                            new SqlParameter($"@{nameof(Category.Picture)}", category.Picture),
                            new SqlParameter($"@{nameof(Category.Id)}", category.Id));

                        return int.Parse(updatedRowId.ToString());
                    }
                }
            }
            catch (BusinessException)
            {
                //Log
                return default;
            }
            catch (SqlException)
            {
                //Log
                return default;
            }
            catch (Exception)
            {
                //Log
                return default;
            }

            return default;
        }

        public int Delete<TEntity>(int id)
        {
            if(id <= 0) throw new BusinessException();

            try
            {
                if ((typeof(TEntity) == typeof(Category)))
                {
                    var insertedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "DeleteCategory", new SqlParameter($"@{nameof(Category.Id)}", id));

                    return int.Parse(insertedRowId.ToString());
                }

                if ((typeof(TEntity) == typeof(Supplier)))
                {
                    var insertedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "DeleteSupplier", new SqlParameter($"@{nameof(Supplier.Id)}", id));

                    return int.Parse(insertedRowId.ToString());
                }

                if ((typeof(TEntity) == typeof(Product)))
                {


                    var insertedRowId = SqlHelper.ExecuteScalar(_connectionString, CommandType.StoredProcedure, "DeleteProduct", new SqlParameter($"@{nameof(Product.Id)}", id));

                    return int.Parse(insertedRowId.ToString());
                }
            }
            catch (BusinessException)
            {
                //Log
                return default;
            }
            catch (SqlException)
            {
                //Log
                return default;
            }
            catch (Exception)
            {
                //Log
                return default;
            }

            return default;
        }

        private void ValidateEntity(IEntity entity)
        {
            SpecificationHandler.HandleSpecificationRequest(entity);
        }
    }
}
