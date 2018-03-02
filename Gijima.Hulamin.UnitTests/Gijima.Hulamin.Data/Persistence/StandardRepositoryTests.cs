using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Core.Validation.Abstracts;
using Gijima.Hulamin.Core.Validation.Concretes;
using Gijima.Hulamin.Data.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Gijima.Hulamin.UnitTests.Gijima.Hulamin.Data
{
    [TestClass]
    public class StandardRepositoryTests
    {
        private ISetUpSpecificationHandler _setUpSpecificationHandler;
        private IRepository _standardRepository;
        private IEntity _entity;

        private string TestValidName => "ValidName";
        private string TestConnectionString => @"Data Source =.\; Initial Catalog = Northwind; Persist Security Info=True;User ID = sa; Password=Khsph01@gmailcom";
        private int TestInvalidNegativeOne => -1;
        private int TestValidOne => 1;

        private bool? TestValidDisconnection => false;

        [TestInitialize]
        public void SetUp()
        {
            _setUpSpecificationHandler = new StandardSetUpSpecificationHandler();
            _standardRepository = new StandardRepository(_setUpSpecificationHandler, TestConnectionString);
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = TestValidDisconnection };
        }
              

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsNull_ThenArgumentExceptionThrown()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(_setUpSpecificationHandler, null));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsEmpty_ThenArgumentExceptionThrown()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(_setUpSpecificationHandler, string.Empty));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsWhiteSpace_ReturnArgumentExceptionThrown()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(_setUpSpecificationHandler, " "));
        }

        #region Create
        [TestMethod]
        public  void Create_OnFailure_WhenTheEntityIsNull_ReturnFalse()
        {
            // Arrange
            _entity = null;

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }        

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestInvalidNegativeOne, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsValidButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestInvalidNegativeOne, Name = TestValidName };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsValidButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestInvalidNegativeOne, Name = TestValidName };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 0, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsValidButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = 0, Name = TestValidName };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsValidButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = 0, Name = TestValidName };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = null, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsValidButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestValidOne, Name = null };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsValidButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestValidOne, Name = null };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = string.Empty, Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsValidButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestValidOne, Name = string.Empty };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsValidButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestValidOne, Name = string.Empty };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsVallidButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = "  ", Discontinued = TestValidDisconnection };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductAndNameAreValidButDisconnectionIsNull_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = null };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }


        [TestMethod]
        public  void Create_OnFailure_WhenTheSupplierIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestValidOne, Name = "  " };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheCategoryIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestValidOne, Name = "  " };

            // Act & Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(_entity));
        }

        [TestMethod]
        public  void Create_OnFailure_WhenTheProductIsValidButNameAlready_ThenThrowsBusinessException()
        {
            // Arrange
            var entityNew = new Product { Id = 2, Name = "NewToBeDuplicated", Discontinued = TestValidDisconnection };
            var entityExists = new Product { Id = 3, Name = "NewToBeDuplicated", Discontinued = TestValidDisconnection };

            _standardRepository = new StandardRepository(_setUpSpecificationHandler, TestConnectionString);

            // Act 
            _standardRepository.Create(entityNew);

            // Assert
            Assert.ThrowsException<BusinessException>(() => _standardRepository.Create(entityExists));
        }

        [TestMethod]
        public  void Create_OnSuccess_WhenTheProductIsValid_ThenDoesNotThrowAnException()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = TestValidDisconnection };
            _standardRepository = new StandardRepository(_setUpSpecificationHandler, TestConnectionString);

            // Act 
            _standardRepository.Create(_entity);

            // Assert

        }
        #endregion

        [TestMethod]
        public  void GetById_OnFailure_WhenTheProductIsValidButIdLessThan0_ThenReturnNull()
        {
            // Arrange
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult =  _standardRepository.GetById(TestInvalidNegativeOne);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public  void GetById_OnFailure_WhenTheProductIsValidButIdIs0_ThenReturnNull()
        {
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardRepository.GetById(0);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public  void GetById_OnFailure_WhenTheProductDoesNotExistInTheDataStore_ThenReturnNull()
        {
            // Arrange
            IEntity expectedResult = null;

            // Act 
            IEntity actualResult = _standardRepository.GetById(-999);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public  void GetById_OnSuccess_WhenTheProductExistsInTheDataStore_ThenReturnProductInstance()
        {
            // Arrange
            _entity = new Product { Id = TestValidOne, Name = TestValidName, Discontinued = TestValidDisconnection };
            int expectedResultId = _standardRepository.Create(_entity);

            // Act 
            IEntity actualResult =  _standardRepository.GetById(_entity.Id);

            // Assert
            Assert.AreEqual(expectedResultId, actualResult.Id);
            Assert.AreEqual(_entity.Name, actualResult.Name);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _entity = null;
            _setUpSpecificationHandler = null;
            _standardRepository = null;
        }
    }
}
