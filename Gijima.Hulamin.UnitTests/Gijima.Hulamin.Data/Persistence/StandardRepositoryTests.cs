using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Abstracts;
using Gijima.Hulamin.Core.Validation.Concretes;
using Gijima.Hulamin.Data.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Gijima.Hulamin.UnitTests.Gijima.Hulamin.Data
{
    [TestClass]
    public class StandardRepositoryTests
    {
        private ISetUpSpecificationHandler _setUpSpecificationHandler;
        private IRepository<Product> _standardProductRepository;
        private IEntity _entity;
        private IRepository<Supplier> _standardSupplierRepository;
        private IRepository<Category> _standardCategoryRepository;

        private string TestValidName => "ValidName";
        private string TestConnectionString => @"Data Source =.\; Initial Catalog = Northwind; Persist Security Info=True;User ID = sa; Password=Khsph01@gmailcom";
        private int TestInvalidNegativeOne => -1;
        private int TestValidOne => 1;

        private bool? TestValidDisconnection => false;

        [TestInitialize]
        public void SetUp()
        {
            _setUpSpecificationHandler = new StandardSetUpSpecificationHandler();
            _standardProductRepository = new StandardRepository<Product>(_setUpSpecificationHandler, TestConnectionString);
            _standardSupplierRepository = new StandardRepository<Supplier>(_setUpSpecificationHandler, TestConnectionString);
            _standardCategoryRepository = new StandardRepository<Category>(_setUpSpecificationHandler, TestConnectionString);
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = TestValidDisconnection };
        }
              

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsNull_ThenArgumentExceptionThrown()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository<Product>(_setUpSpecificationHandler, null));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsEmpty_ThenArgumentExceptionThrown()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository<Product>(_setUpSpecificationHandler, string.Empty));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsWhiteSpace_ReturnArgumentExceptionThrown()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository<Product>(_setUpSpecificationHandler, " "));
        }

        #region Create
        [TestMethod]
        public  void Create_OnFailure_WhenTheEntityIsNull_ReturnFalse()
        {
            // Arrange
            _entity = null;

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Create(_entity));
        }        

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestInvalidNegativeOne, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsValidButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestInvalidNegativeOne, Name = TestValidName };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsValidButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestInvalidNegativeOne, Name = TestValidName };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 0, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsValidButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = 0, Name = TestValidName };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsValidButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = 0, Name = TestValidName };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = null, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsValidButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestValidOne, Name = null };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsValidButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestValidOne, Name = null };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = string.Empty, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsValidButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestValidOne, Name = string.Empty };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsValidButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestValidOne, Name = string.Empty };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsVallidButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = "  ", Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductAndNameAreValidButDisconnectionIsNull_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = null };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Create(_entity));
        }
        
        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestValidOne, Name = "  " };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestValidOne, Name = "  " };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.Create(_entity));
        }
       
        [TestMethod]
        public  void Create_OnSuccess_WhenTheProductIsValid_ThenDoesNotThrowAnException()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = TestValidDisconnection };
            _standardProductRepository = new StandardRepository<Product>(_setUpSpecificationHandler, TestConnectionString);

            // Act 
            _standardProductRepository.Create(_entity);

            // Assert
        }
        #endregion

        #region Update

        [TestMethod]
        public void Update_OnFailure_WhenTheEntityIsNull_ReturnFalse()
        {
            // Arrange
            _entity = null;

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Update(_entity));
        }

        [TestMethod]
        public void Update_OnFailure_WhenTheProductIsValidButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestInvalidNegativeOne, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Update(_entity));
        }

        [TestMethod]
        public void Update_OnFailure_WhenTheProductIsValidButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 0, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Update(_entity));
        }

        [TestMethod]
        public void Update_OnFailure_WhenTheProductIsValidButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = null, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Update(_entity));
        }

        [TestMethod]
        public void Update_OnFailure_WhenTheProductIsValidButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = string.Empty, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Update(_entity));
        }

        [TestMethod]
        public void Update_OnFailure_WhenTheProductIsVallidButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = "  ", Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Update(_entity));
        }

        [TestMethod]
        public void Update_OnFailure_WhenTheProductAndNameAreValidButDisconnectionIsNull_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = null };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Update(_entity));
        }

        [TestMethod]
        public void Update_OnSuccess_WhenTheProductIsValid_ThenDoesNotThrowAnException()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = TestValidDisconnection };
            _standardProductRepository = new StandardRepository<Product>(_setUpSpecificationHandler, TestConnectionString);

            // Act 
            int expectedResult = _standardProductRepository.Update(_entity);

            // Assert
            Assert.AreEqual(_entity.Id, expectedResult);
        }

        [TestMethod]
        public void Update_OnSuccess_WhenTheSupplierIsValid_ThenDoesNotThrowAnException()
        {
            // Arrange
            _entity = new Supplier { Id = TestValidOne, Name = TestValidName };
            _standardSupplierRepository = new StandardRepository<Supplier>(_setUpSpecificationHandler, TestConnectionString);

            // Act 
            int expectedResult = _standardSupplierRepository.Update(_entity);

            // Assert
            Assert.AreEqual(_entity.Id, expectedResult);
        }

        [TestMethod]
        public void Update_OnSuccess_WhenTheCategoryIsValid_ThenDoesNotThrowAnException()
        {
            // Arrange
            _entity = new Category { Id = TestValidOne, Name = TestValidName, Picture = new byte[] { 1 } };
            _standardCategoryRepository = new StandardRepository<Category>(_setUpSpecificationHandler, TestConnectionString);

            // Act 
            int expectedResult = _standardCategoryRepository.Update(_entity);

            // Assert
            Assert.AreEqual(_entity.Id, expectedResult);
        }

        #endregion

        [Ignore]
        [TestMethod]
        public void GetAll_OnFailure_WhenTheProductIsDataStoreIsEmpty_ThenReturnEmptyList()
        {
            // Arrange
            var expectedResult = new List<Product>();

            // Act 
            var actualResult = _standardProductRepository.GetAll<Product>();

            // Assert
            Assert.AreEqual(0, actualResult.Count);
        }

        [TestMethod]
        public void GetAll_OnSuccess_WhenTheProductDataStoreIsNotEmpty_ThenReturnTheList()
        {
            // Act 
            var actualResult = _standardProductRepository.GetAll<Product>();

            // Assert
            Assert.IsTrue(actualResult.Count > 0);
        }

        [TestMethod]
        public void GetAll_OnSuccess_WhenTheSupplierDataStoreIsNotEmpty_ThenReturnTheList()
        {
            // Act 
            var actualResult = _standardSupplierRepository.GetAll<Supplier>();

            // Assert
            Assert.IsTrue(actualResult.Count > 0);
        }

        #region GetById
        [TestMethod]
        public void GetById_OnFailure_WhenTheProductIsValidButIdLessThan0_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.GetById<Product>(TestInvalidNegativeOne));
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheSupplierIsValidButIdLessThan0_ThenThowBusnessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.GetById<Product>(TestInvalidNegativeOne));
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheCategoryIsValidButIdLessThan0_ThenReturnNull()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.GetById<Category>(0));
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheProductIsValidButIdIs0_ThenReturnNull()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.GetById<Product>(0));
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheSupplierIsValidButIdIs0_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.GetById<Supplier>(0));
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheCategoryIsValidButIdIs0_ThenReturnNull()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.GetById<Category>(0));
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheProductDoesNotExistInTheDataStore_ThenReturnNull()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.GetById<Product>(0));
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheSupplierDoesNotExistInTheDataStore_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.GetById<Supplier>(-999));
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheCatgoryDoesNotExistInTheDataStore_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.GetById<Category>(-999));
        }

        [TestMethod]
        public void GetById_OnSuccess_WhenTheProductExistsInTheDataStore_ThenReturnProductInstance()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = TestValidDisconnection };
            
            // Act 
            IEntity actualResult = _standardProductRepository.GetById<Product>(_entity.Id);

            // Assert
            Assert.AreEqual(_entity.Id, actualResult.Id);
            Assert.AreEqual(_entity.Name, actualResult.Name);
        }

        [Ignore]
        [TestMethod]
        public void GetById_OnSuccess_WhenTheSupplierExistsInTheDataStore_ThenReturnSupplierInstance()
        {
            // Arrange
            _entity = new Supplier { Id = TestValidOne, Name = TestValidName };
            int expectedResultId = _standardSupplierRepository.Create(_entity);

            // Act 
            IEntity actualResult = _standardSupplierRepository.GetById<Supplier>(expectedResultId);

            // Assert
            Assert.AreEqual(expectedResultId, actualResult.Id);
            Assert.AreEqual(_entity.Name, actualResult.Name);
        }

        [Ignore]
        [TestMethod]
        public void GetById_OnSuccess_WhenTheCategoryExistsInTheDataStore_ThenReturnCategoryInstance()
        {
            // Arrange
            _entity = new Category { Id = TestValidOne, Name = TestValidName, Picture = new byte[] { 1 } };
            int expectedResultId = _standardCategoryRepository.Create(_entity);

            // Act 
            IEntity actualResult = _standardCategoryRepository.GetById<Category>(expectedResultId);

            // Assert
            Assert.AreEqual(expectedResultId, actualResult.Id);
            Assert.AreEqual(_entity.Name, actualResult.Name);
        }
        #endregion

        #region Delete
        [TestMethod]
        public void Delete_OnFailure_WhenTheProductIsValidButIdLessThan0_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Delete<Product>(TestInvalidNegativeOne));
        }

        [TestMethod]
        public void Delete_OnSuccess_WhenTheProductExistsInTheDataStore_ThenReturnTheIdOfTheDeletedInstance()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act 
            var actualResult = _standardProductRepository.Delete<Product>(_entity.Id);

            // Assert
            Assert.AreEqual(_entity.Id, actualResult);
        }

        [TestMethod]
        public void Delete_OnFailure_WhenTheProductIsValidButIdIs0_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardProductRepository.Delete<Product>(0));
        }

        [TestMethod]
        public void Delete_OnFailure_WhenTheSupplierIsValidButIdLessThan0_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.Delete<Supplier>(TestInvalidNegativeOne));
        }

        [TestMethod]
        public void Delete_OnFailure_WhenTheSupplierIsValidButIdIs0_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardSupplierRepository.Delete<Supplier>(0));
        }

        [TestMethod]
        public void Delete_OnFailure_WhenTheCategoryIsValidButIdLessThan0_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.Delete<Category>(TestInvalidNegativeOne));
        }

        [TestMethod]
        public void Delete_OnFailure_WhenTheCategoryIsValidButIs0_ThenThrowBusinessException()
        {
            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardCategoryRepository.Delete<Category>(0));
        }
        #endregion

        [TestCleanup]
        public void CleanUp()
        {
            _entity = null;
            _setUpSpecificationHandler = null;
            _standardProductRepository = null;
            _standardCategoryRepository = null;
            _standardSupplierRepository = null;
        }
    }
}
