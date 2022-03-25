using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingLegacyContext.Models;
using UnitTestingLegacyContext.SomeNewFunctionality;

namespace LegacyTests.SomeNewFunctionalityTests
{
    public class DataOperationsTests
    {
        private Mock<ContextService> _mock;
        private DataOperations _dataOperations;

        [SetUp]
        public void Setup()
        {
            _mock = new Mock<ContextService>();
            _mock.Setup(x => x.GetUserByID(1)).Returns(new User() { Id = 1 });
            _mock.Setup(x => x.GetUserByID(2)).Returns(new User() { Id = 2 });
            _mock.Setup(x => x.AddUser(It.IsNotNull<string>())).Returns(3);

            _dataOperations = new DataOperations(_mock.Object);
        }

        [Test]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        public int Can_GetUser(int id)
        {
            var userId = _dataOperations.GetUser(id);
            return userId.Id;
        }

        [Test]
        public void Can_AddUser()
        {
            var id = _dataOperations.AddNewUser("R2D2");
            Assert.AreEqual(3, id);
        }
    }
}
