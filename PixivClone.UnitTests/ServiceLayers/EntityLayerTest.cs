using System.Diagnostics;
using NUnit.Framework;
using PixivClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using PixivClone.ServiceLayers;

namespace PixivClone.UnitTests.ServiceLayers
{
    [TestFixture]
    class EntityLayerTest
    {
        private IRepository<User> _repo;
        private EntityService<User> _entityService;

        [TestFixtureSetUp]
        public void SetupTestFixture()
        {
            _repo = Mock.Create<IRepository<User>>();
            _entityService = new EntityService<User>(_repo);
        }

        [Test]
        public void WhenAUserIsCreatedThenRepoAddMethodIsCalledOnce()
        {
            //Arrange
            var user = new User() { UserId = Guid.NewGuid(), Username = "Splatch" };
            Mock.Arrange(() => _repo.Add(user)).OccursOnce();

            //Act
            _entityService.Add(user);

            //Assert
            Mock.Assert(_entityService);
        }

        [Test]
        public void WhenAUserIsCreatedThenTheUserListShouldContainOneMoreUser()
        {
            //Arrange
            var userList = new List<User>
            { 
                new User(){ UserId = Guid.NewGuid(), Username = "Ekanseht" },
                new User(){ UserId = Guid.NewGuid(), Username = "Malahony" },
                new User(){ UserId = Guid.NewGuid(), Username = "Sploutch" }    
            };
            var user = new User() { UserId = Guid.NewGuid(), Username = "Splatch" };
            Mock.Arrange(() => _repo.Add(Arg.IsAny<User>())).DoInstead(() => userList.Add(user));

            //Act
            _entityService.Add(user); 

            //Assert
            Mock.Assert(_repo);
            Assert.AreEqual(userList.Count, 4);
        }

        [Test]
        public void WhenAUserIsCreatedThenThatUserShouldExistInData()
        {
            //Arrange
            var userList = new List<User>
            { 
                new User(){ UserId = Guid.NewGuid(), Username = "Ekanseht" },
                new User(){ UserId = Guid.NewGuid(), Username = "Malahony" } 
            };
            var user = new User() { UserId = Guid.NewGuid(), Username = "Sploutch" };
            var found = false;
            Mock.Arrange(() => _repo.Add(Arg.IsAny<User>())).DoInstead(() => userList.Add(user));

            //Act
            _entityService.Add(user);
            foreach (User us in userList)
            {
                if (us == user)
                    found = true;
            }


            //Assert
            Mock.Assert(_repo);
            Assert.IsTrue(found);
        }

        [Test]
        public void WhenTheListOfUsersIsRequestedThenAListOfTheCorrectSizeShouldBeReturned()
        {
            //Arrange
            var userList = new List<User>
            { 
                new User(){ UserId = Guid.NewGuid(), Username = "Ekanseht" },
                new User(){ UserId = Guid.NewGuid(), Username = "Malahony" },
                new User(){ UserId = Guid.NewGuid(), Username = "Sploutch" }  
            };
            Mock.Arrange(() => _repo.GetAll()).Returns(userList.AsQueryable());

            //Act
            _entityService.GetAll();

            //Assert
            Mock.Assert(_repo);
            Assert.AreEqual(userList.Count, 3);
        }

        [Test]
        public void WhenAUserIsDeletedThenTheUserListShouldContainOneLessUser()
        {
            //Arrange
            var userList = new List<User>
            { 
                new User(){ UserId = Guid.NewGuid(), Username = "Ekanseht" },
                new User(){ UserId = Guid.NewGuid(), Username = "Malahony" } 
            };
            var user = new User() { UserId = Guid.NewGuid(), Username = "Sploutch" };
            userList.Add(user);
            Mock.Arrange(() => _repo.Delete(Arg.IsAny<User>())).DoInstead(() => userList.RemoveAt(0));

            //Act
            _entityService.Delete(user);

            //Assert
            Mock.Assert(_repo);
            Assert.AreEqual(userList.Count, 2);
        }

        [Test]
        public void WhenAUserIsDeletedThenThatUserShouldNotExistAnymoreInData()
        {
            //Arrange
            var userList = new List<User>
            { 
                new User(){ UserId = Guid.NewGuid(), Username = "Ekanseht" },
                new User(){ UserId = Guid.NewGuid(), Username = "Malahony" } 
            };
            var user = new User() { UserId = Guid.NewGuid(), Username = "Sploutch" };
            userList.Add(user);
            var found = false;
            Mock.Arrange(() => _repo.Delete(Arg.IsAny<User>())).DoInstead(() => userList.RemoveAt(2));

            //Act
            _entityService.Delete(user);
            foreach(User us in userList) {
                if (us == user)
                    found = true;
            }
            

            //Assert
            Mock.Assert(_repo);
            Assert.IsFalse(found);
        }

        [Test]
        public void WhenSeveralUsersAreDeletedThenTheseUsersShouldNotExistAnyMoreInData()
        {
            //Arrange
            var userList = new List<User>
            { 
                new User(){ UserId = Guid.NewGuid(), Username = "Ekanseht" },
                new User(){ UserId = Guid.NewGuid(), Username = "Malahony" },
                new User(){ UserId = Guid.NewGuid(), Username = "Sploutch" }
            };
            var found = false;
            Mock.Arrange(() => _repo.DeleteAll(Arg.IsAny<IEnumerable<User>>())).DoInstead(() =>  userList.RemoveAll(new Predicate<User>(x => x.Username == "Malahony")) );
           
            //Act
            _entityService.DeleteAll(userList);
            foreach (User us in userList)
            {
                if (us.Username == "Malahony")
                    found = true;
            }

            //Assert
            Mock.Assert(_repo);
            Assert.IsFalse(found);
        }

        [Test]
        public void WhenAUserIsUpdatedThenMethodUpdateShouldBeCalledOnce()
        {
            //Arrange
            var user = new User(){ UserId = Guid.NewGuid(), Username = "TestingUser" };
            Mock.Arrange(() => _repo.Update(Arg.IsAny<User>())).OccursOnce();

            //Act
            _entityService.Update(user);

            //Assert
            Mock.Assert(_repo);
        }

        [Test]
        public void WhenAUserUsernameIsUpdatedThenTheUserUsernameShouldHaveChangedAsAsked()
        {
            //Arrange
            var userList = new List<User>
            { 
                new User(){ UserId = Guid.NewGuid(), Username = "Ekanseht" },
                new User(){ UserId = Guid.NewGuid(), Username = "Malahony" },
                new User(){ UserId = Guid.NewGuid(), Username = "Sploutch" }
            };
            var user = new User() { UserId = userList[0].UserId, Username = "TestingUser" };
            Mock.Arrange(() => _repo.Update(Arg.IsAny<User>())).DoInstead(() => userList.Where(d => d.UserId == user.UserId).First().Username = user.Username);
            
            //Act
            _entityService.Update(user);

            //Assert
            Mock.Assert(_repo);
            Assert.AreEqual(userList.Where(d => d.UserId == userList[0].UserId).First().Username, user.Username);
        }
    }
}
