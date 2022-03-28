using C08_Classes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08_NUnit
{
    [TestFixture]
    public class ProductNUnitTests
    {

        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWithDiscount()
        {
            Product product = new Product() { Price = 50 };
            var result = product.GetPrice(new Customer { IsPlatinum = true });

            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void GetProductPriceBadMoqUsing_PlatinumCustomer_ReturnPriceWithDiscount()
        {
            Product product = new Product() { Price = 50 };
            var customer = new Mock<ICustomer>();
            customer.Setup(x => x.IsPlatinum).Returns(true);
            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(40));
        }
    }
}
