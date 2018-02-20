﻿using Gijima.Hulamin.Core.Entities;
using Gijima.Hulamin.Core.Exceptions;
using Gijima.Hulamin.Data.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Gijima.Hulamin.UnitTests.Gijima.Hulamin.Data
{
    [TestClass]
    public class StandardRepositoryTests
    {
        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsNull_ReturnThrowAnArgumentException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(null));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsEmpty_ReturnArgumentExceptionThrown()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(string.Empty));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsWhiteSpace_ReturnArgumentExceptionThrown()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(" "));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheEntityIsNull_ReturnFalse()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = null;

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => standardRepository.CreateAsync(entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButIdLessThan0_ReturnBusinessExceptionThrown()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = -1, Name = "FakeName" };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => standardRepository.CreateAsync(entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButIdIs0_ReturnBusinessExceptionThrown()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = 0, Name = "FakeName" };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => standardRepository.CreateAsync(entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsNull_ReturnBusinessExceptionThrown()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = 1, Name = null };
            
            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => standardRepository.CreateAsync(entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsEmpty_ReturnBusinessExceptionThrown()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = 1, Name = string.Empty };
            
            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => standardRepository.CreateAsync(entity));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsWhiteSpace_ReturnBusinessExceptionThrown()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = 1, Name = "  " };

            // Act & Assert
            await Assert.ThrowsExceptionAsync<BusinessException>(() => standardRepository.CreateAsync(entity));
        }
    }
}