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
        private string TestConnectionString => "TestConnectionString";
        private int TestInvalidNegativeOne => -1;

        private bool? TestValidDisconnection => false;

        [TestInitialize]
        public void SetUp()
        {
            _setUpSpecificationHandler = new StandardSetUpSpecificationHandler();
            _standardRepository = new StandardRepository(_setUpSpecificationHandler, TestConnectionString);
            _entity = null;
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

        [TestMethod]
        public async Task Create_OnFailure_WhenTheEntityIsNull_ReturnFalse()
        {
            // Arrange
            _entity = null;

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = TestInvalidNegativeOne, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheSupplierIsNotNullButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = TestInvalidNegativeOne, Name = TestValidName };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheCategoryIsNotNullButIdLessThan0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = TestInvalidNegativeOne, Name = TestValidName };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 0, Name = TestValidName, Discontinued = TestValidDisconnection };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheSupplierIsNotNullButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = 0, Name = TestValidName };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheCategoryIsNotNullButIdIs0_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = 0, Name = TestValidName };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = null, Discontinued = TestValidDisconnection };
            
            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheSupplierIsNotNullButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = 1, Name = null };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheCategoryIsNotNullButNameIsNull_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = 1, Name = null };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = string.Empty, Discontinued = TestValidDisconnection };
            
            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheSupplierIsNotNullButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = 1, Name = string.Empty };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheCategoryIsNotNullButNameIsEmpty_ThenBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = 1, Name = string.Empty };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = "  ", Discontinued = TestValidDisconnection };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductAndNameAreValidButDisconnectionIsNull_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = TestValidName, Discontinued = null };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }


        [TestMethod]
        public async Task Create_OnFailure_WhenTheSupplierIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Supplier { Id = 1, Name = "  " };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheCategoryIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Category { Id = 1, Name = "  " };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnSuccess_WhenTheProductIsValid_ThenDoesNotThrowXnException()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = TestValidName, Discontinued = TestValidDisconnection };
            _standardRepository = new StandardRepository(_setUpSpecificationHandler, @"Data Source=.\;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=Khsph01@gmailcom");
            // Act 
            await _standardRepository.CreateAsync(_entity);

            // Assert            
        }
    }
}
