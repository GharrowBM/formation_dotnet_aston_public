using C08_Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08_NUnit
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstNameAndLastName_ReturnFullName()
        {
            // Arrange

            // Act
            _customer.CombineNames("John", "SMITH");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_customer.GreetMessage, "Hello, John SMITH");
                Assert.That(_customer.GreetMessage, Is.EqualTo("Hello, John SMITH"));
                Assert.That(_customer.GreetMessage, Does.Contain("S"));
                Assert.That(_customer.GreetMessage, Does.Contain("mIT").IgnoreCase);
                Assert.That(_customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(_customer.GreetMessage, Does.EndWith("TH"));
                Assert.That(_customer.GreetMessage, Does.Match(@"Hello, \w+ \w+"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.IsNull(_customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = _customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNutNull()
        {
            _customer.CombineNames("John", "");

            Assert.IsNotNull(_customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(_customer.GreetMessage));
            Assert.AreEqual("Hello, John ", _customer.GreetMessage);
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _customer.CombineNames("", "OBAMA"));
            Assert.That(() => _customer.CombineNames("", "TRUMP"),
                Throws.ArgumentException);

            var exceptionDetails = Assert.Throws<ArgumentException>(() => _customer.CombineNames("", "SMITH"));
            Assert.AreEqual("Empty firstName", exceptionDetails.Message);

            Assert.That(() => _customer.CombineNames("", "MITCHEL"),
                Throws.ArgumentException.With.Message.EqualTo("Empty firstName"));

        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100OrderTotal_ReturnBasicCustomer()
        {
            // Arrange
            _customer.OrderTotal = 10;

            // Act
            var result = _customer.GetCustomerDetails();

            // Assert
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100OrderTotal_ReturnPlatinumCustomer()
        {
            // Arrange
            _customer.OrderTotal = 1000;

            // Act
            var result = _customer.GetCustomerDetails();

            // Assert
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
