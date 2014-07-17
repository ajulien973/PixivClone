using System;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using Telerik.JustMock;
using PixivClone.Controllers;

namespace PixivClone.UnitTests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IHomeController _controller;

        [TestFixtureSetUp]
        public void SetupTestFixture()
        {
            _controller = Mock.Create<HomeController>();
        }

        [Test]
        public void Index()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
