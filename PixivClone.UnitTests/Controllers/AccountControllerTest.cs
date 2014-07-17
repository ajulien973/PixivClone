using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PixivClone.Controllers;
using Telerik.JustMock;
using PixivClone.Models;

namespace PixivClone.UnitTests.Controllers
{
    [TestFixture]
    class AccountControllerTest
    {
        private IAccountController _controller;
        private IRepository<User> _userRepository;

        [TestFixtureSetUp]
        public void SetupTestFixture()
        {
            _userRepository = Mock.Create<IRepository<User>>();
            _controller = new AccountController(_userRepository);
        }

        [Test]
        public void WhenUserIsCreatedCheckThatMethodAddIsCalledOnce()
        {
            //Arrange
            var user = new User { UserId = Guid.NewGuid(), Username = "Ekanseht" };
            Mock.Arrange(() => _userRepository.Add(user)).OccursOnce();
            
            //Act
            _controller.Create(user);

            //Assert
            Mock.Assert(_controller);
        }
    }
}