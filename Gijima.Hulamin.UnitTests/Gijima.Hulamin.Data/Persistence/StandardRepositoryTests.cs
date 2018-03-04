using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Abstracts;
using Gijima.Hulamin.Core.Validation.Concretes;
using Gijima.Hulamin.Data.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        #region GetById
        [TestMethod]
        public void GetById_OnFailure_WhenTheProductIsValidButIdLessThan0_ThenReturnNull()
        {
            // Arrange
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardProductRepository.GetById<Product>(TestInvalidNegativeOne);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheSupplierIsValidButIdLessThan0_ThenReturnNull()
        {
            // Arrange
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardSupplierRepository.GetById<Supplier>(TestInvalidNegativeOne);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheCategoryIsValidButIdLessThan0_ThenReturnNull()
        {
            // Arrange
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardCategoryRepository.GetById<Category>(TestInvalidNegativeOne);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheProductIsValidButIdIs0_ThenReturnNull()
        {
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardProductRepository.GetById<Product>(0);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheSupplierIsValidButIdIs0_ThenReturnNull()
        {
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardSupplierRepository.GetById<Supplier>(0);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheCategoryIsValidButIdIs0_ThenReturnNull()
        {
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardCategoryRepository.GetById<Category>(0);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheProductDoesNotExistInTheDataStore_ThenReturnNull()
        {
            // Arrange
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardProductRepository.GetById<Product>(-999);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheSupplierDoesNotExistInTheDataStore_ThenReturnNull()
        {
            // Arrange
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardSupplierRepository.GetById<Supplier>(-999);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetById_OnFailure_WhenTheCatgoryDoesNotExistInTheDataStore_ThenReturnNull()
        {
            // Arrange
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardCategoryRepository.GetById<Category>(-999);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
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
