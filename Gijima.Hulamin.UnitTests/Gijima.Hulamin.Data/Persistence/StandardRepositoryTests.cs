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

        [TestInitialize]
        public void SetUp()
        {
            _setUpSpecificationHandler = new StandardSetUpSpecificationHandler();
            _standardRepository = new StandardRepository(_setUpSpecificationHandler, "FakeConnectionString");
            _entity = new Product { Id = 1, Name = "FakeName" };
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsNull_ReturnThrowAnArgumentException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(_setUpSpecificationHandler, null));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsEmpty_ReturnArgumentExceptionThrown()
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
        public async Task Create_OnFailure_WhenTheProductIsNotNullButIdLessThan0_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity.Id = -1;

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButIdIs0_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity.Id = 0;

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsNull_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = null };
            
            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsEmpty_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = string.Empty };
            
            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            _entity = new Product { Id = 1, Name = "  " };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => _standardRepository.CreateAsync(_entity));
        }
    }
}
