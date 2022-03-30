using EX04_API.Controllers;
using EX04_API.Datas;
using EX04_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX04_NUnitTest
{
    [TestFixture]
    public class AddressesControllerNUnitTests
    {
        private AddressesController _controller;
        private Mock<IRepository<Address>> _repoMock;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IRepository<Address>>();
            _controller = new AddressesController(new Mock<ILogger<AddressesController>>().Object, _repoMock.Object);
        }

        [Test]
        public void AddAddress_InvalidModelState_ReturnBadRequest()
        {
            var invalidModel = new Address()
            {
                StreetNumber = 404,
                StreetName = "Rue des Templiers"
            };

            var result = _controller.AddAddress(invalidModel);

            Assert.That(result, Is.InstanceOf(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void AddAddress_ValidModelStateAndUnableToAddInDatabase_ReturnBadRequest()
        {
            var someAddress = new Address()
            {
                StreetNumber = 404,
                StreetName = "Rue des Templiers",
                PostalCode = 59000,
                CityName = "Lille"
            };

            _repoMock.Setup(x => x.Add(It.IsAny<Address>())).Returns(default(Address));
            var result = _controller.AddAddress(someAddress);

            Assert.That(result, Is.InstanceOf(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void AddAddress_ValidModelStateAndAbleToAddInDatabase_ReturnOk()
        {
            var someAddress = new Address()
            {
                StreetNumber = 404,
                StreetName = "Rue des Templiers",
                PostalCode = 59000,
                CityName = "Lille"
            };

            var addedAddress = new Address()
            {
                Id = 1,
                StreetName = someAddress.StreetName,
                StreetNumber = someAddress.StreetNumber,
                PostalCode = someAddress.PostalCode,
                CityName = someAddress.CityName
            };

            _repoMock.Setup(x => x.Add(It.IsAny<Address>())).Returns(addedAddress);
            var result = _controller.AddAddress(someAddress);

            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void GetAll_NoAddressesInDatabase_ReturnNotFound()
        {
            var expectedList = new List<Address>();
            _repoMock.Setup(x => x.GetAll()).Returns(expectedList);
            var result = _controller.GetAllAddresses();

            Assert.That(result, Is.InstanceOf(typeof(NotFoundObjectResult)));
        }

        [Test]
        public void GetAll_SomeAddressesInDatabase_ReturnOk()
        {
            var expectedList = new List<Address>()
            {
                new Address()
                {
                    Id = 1,
                    StreetNumber = 404,
                    StreetName = "Rue des Templiers",
                    PostalCode = 59000,
                    CityName = "Lille"
                }
            };

            _repoMock.Setup(x => x.GetAll()).Returns(expectedList);
            var result = _controller.GetAllAddresses();

            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void GetSpecificAddress_UnexistingAddressInDatabase_ReturnNotFound()
        {
            _repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(default(Address));
            var result = _controller.GetAddress(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(NotFoundObjectResult)));
        }

        [Test]
        public void GetSpecificAddress_ExistingAddressInDatabase_ReturnOk()
        {
            var someAddress = new Address()
            {
                Id = 1,
                StreetNumber = 404,
                StreetName = "Rue des Templiers",
                PostalCode = 59000,
                CityName = "Lille"
            };

            _repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(someAddress);
            var result = _controller.GetAddress(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void UpdateAddress_UnexistingAddressInDatabase_ReturnNotFound()
        {
            _repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(default(Address));
            var result = _controller.UpdateAddress(It.IsAny<int>(), It.IsAny<Address>());

            Assert.That(result, Is.InstanceOf(typeof(NotFoundObjectResult)));
        }

        [Test]
        public void UpdateAddress_ExistingAddressButUnableToEditInDB_ReturnBadRequest()
        {
            var someAddress = new Address()
            {
                Id = 1,
                StreetNumber = 404,
                StreetName = "Rue des Templiers",
                PostalCode = 59000,
                CityName = "Lille"
            };

            _repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(someAddress);
            _repoMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Address>())).Returns(default(Address));

            var result = _controller.UpdateAddress(It.IsAny<int>(), It.IsAny<Address>());

            Assert.That(result, Is.InstanceOf(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void UpdateAddress_ExistingAddressAndAbleToEditInDB_ReturnOk()
        {
            var someAddress = new Address()
            {
                Id = 1,
                StreetNumber = 404,
                StreetName = "Rue des Templiers",
                PostalCode = 59000,
                CityName = "Lille"
            };

            var editedAddress = new Address()
            {
                Id = 1,
                StreetNumber = 404,
                StreetName = "Rue des Accacia",
                PostalCode = 59000,
                CityName = "Lille"
            };

            _repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(someAddress);
            _repoMock.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<Address>())).Returns(editedAddress);

            var result = _controller.UpdateAddress(It.IsAny<int>(), It.IsAny<Address>());

            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
        }

        [Test]
        public void DeleteAddress_UnexistingAddressInDatabase_ReturnNotFound()
        {
            _repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(default(Address));
            var result = _controller.DeleteAddress(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(NotFoundObjectResult)));
        }

        [Test]
        public void DeleteAddress_ExistingAddressButUnableToDeleteInDB_ReturnBadRequest()
        {
            var someAddress = new Address()
            {
                Id = 1,
                StreetNumber = 404,
                StreetName = "Rue des Templiers",
                PostalCode = 59000,
                CityName = "Lille"
            };

            _repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(someAddress);
            _repoMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(false);

            var result = _controller.DeleteAddress(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void DeleteAddress_ExistingAddressAndAbleToDeleteInDB_ReturnOk()
        {
            var someAddress = new Address()
            {
                Id = 1,
                StreetNumber = 404,
                StreetName = "Rue des Templiers",
                PostalCode = 59000,
                CityName = "Lille"
            };

            _repoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(someAddress);
            _repoMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            var result = _controller.DeleteAddress(It.IsAny<int>());

            Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
        }
    }
}
