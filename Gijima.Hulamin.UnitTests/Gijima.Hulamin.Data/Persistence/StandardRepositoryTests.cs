using Gijima.Hulamin.Core.Entities;
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
            // Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(null));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsEmpty_ReturnThrowAnArgumentException()
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(string.Empty));
        }

        [TestMethod]
        public void StandardRepository_OnFailure_WhenTheConnectionStringIsWhiteSpace_ReturnThrowAnArgumentException()
        {
            // Assert
            Assert.ThrowsException<ArgumentException>(() => new StandardRepository(" "));
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheEntityIsNull_ReturnFalse()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = null;
            bool expectedResult = false;

            // Act 
            bool actualResult = await standardRepository.CreateAsync(entity);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButIdLessThan0_ReturnFalse()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = -1, Name = "FakeName" };
            bool expectedResult = false;

            // Act 
            bool actualResult = await standardRepository.CreateAsync(entity);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButIdIs0_ReturnFalse()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = 0, Name = "FakeName" };
            bool expectedResult = false;

            // Act 
            bool actualResult = await standardRepository.CreateAsync(entity);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsNull_ReturnFalse()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = 1, Name = null };
            bool expectedResult = false;

            // Act 
            bool actualResult = await standardRepository.CreateAsync(entity);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsEmpty_ReturnFalse()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = 1, Name = string.Empty };
            bool expectedResult = false;

            // Act 
            bool actualResult = await standardRepository.CreateAsync(entity);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public async Task Create_OnFailure_WhenTheProductIsNotNullButNameIsWhiteSpace_ReturnFalse()
        {
            // Arrange
            var standardRepository = new StandardRepository("FakeConnectionString");
            IEntity entity = new Product { Id = 1, Name = "  " };
            bool expectedResult = false;

            // Act 
            bool actualResult = await standardRepository.CreateAsync(entity);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
