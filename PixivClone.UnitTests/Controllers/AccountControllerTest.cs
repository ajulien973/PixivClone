using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PixivClone.Controllers;
using Telerik.JustMock;
using PixivClone.Models;
using PixivClone.ServiceLayers;

namespace PixivClone.UnitTests.Controllers
{
    [TestFixture]
    class AccountControllerTest
    {
        private IAccountController _controller;
        private IEntityService<User> _entityService;

        [TestFixtureSetUp]
        public void SetupTestFixture()
        {
            _entityService = Mock.Create<IEntityService<User>>();
            _controller = new AccountController(_entityService);
        }
    }
}