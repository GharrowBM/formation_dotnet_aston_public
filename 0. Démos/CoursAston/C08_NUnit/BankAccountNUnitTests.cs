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
    public class BankAccountNUnitTests
    {
        private BankAccount _bankAccount;

        [SetUp]
        public void Setup()
        {
            //_bankAccount = new BankAccount(new LogBook()); // N'est pas un test unitaire mais un test d'intégration 
            //_bankAccount = new BankAccount(new LogFakker()); // Demande de créer un nouvel objet pour chaque objet, donc impensable dans un vrai projet
        }

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogger>();
            logMock.Setup(x => x.Log("Paramètre"));
            _bankAccount = new BankAccount(logMock.Object);

            var result = _bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(_bankAccount.Balance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        public void BankWithdrawal_Withdraw100With2000Balance_ReturnTrue(decimal balance, decimal amount)
        {
            var logMock = new Mock<ILogger>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<decimal>(x => x > 0))).Returns(true);
            _bankAccount = new BankAccount(logMock.Object);

            _bankAccount.Deposit(balance);
            var result = _bankAccount.WithDrawal(amount);

            Assert.IsTrue(result);

        }

        [Test]
        [TestCase(100, 300)]
        public void BankWithdrawal_Withdraw300With1000Balance_ReturnFalse(decimal balance, decimal amount)
        {
            var logMock = new Mock<ILogger>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<decimal>(x => x > 0))).Returns(true);
            //logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<decimal>(x => x < 0))).Returns(false); // Optionnel car False est la valeur par défaut d'un bool
            _bankAccount = new BankAccount(logMock.Object);

            _bankAccount.Deposit(balance);
            var result = _bankAccount.WithDrawal(amount);

            Assert.IsFalse(result);

        }

        // Si on veut tester le Logger depuis la classe BankAccount, on peut le faire via Moq
        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue() 
        {
            var logMock = new Mock<ILogger>();
            string desiredOutput = "blabla";

            logMock.Setup(x => x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnStr("BlaBla"), Is.EqualTo(desiredOutput));

        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogger>();
            string desiredOutput = "Hello";

            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";

            Assert.IsTrue(logMock.Object.LogWithOutputResult("Clark", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));

        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogger>();
            Customer customer = new();
            Customer customerNotUser = new();

            logMock.Setup(x => x.LogWithCustomerRef(ref customer)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithCustomerRef(ref customer));
            Assert.IsFalse(logMock.Object.LogWithCustomerRef(ref customerNotUser));

        }

        [Test]
        public void BankLogDummy_SetAndGetLogSeverityAndLogTypeMock_ReturnTrue()
        {
            var logMock = new Mock<ILogger>();
            logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("Information");
            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("Information"));
            logMock.SetupAllProperties();
            logMock.Object.LogSeverity = 9000;
            logMock.Object.LogType = "Danger";
            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(9000));
            Assert.That(logMock.Object.LogType, Is.EqualTo("Danger"));
        }

        [Test]
        public void BankLogDummy_CallbackExample_ReturnTrue()
        {
            // Callback A
            var logMock = new Mock<ILogger>();
            string logTemp = "Hello, ";
            logMock.Setup(x => x.LogToDb(It.IsAny<string>()))
                .Returns(true).Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Sarah");

            Assert.That(logTemp, Is.EqualTo("Hello, Sarah"));

            // Callback B
            int counter = 5;
            logMock.Setup(x => x.LogToDb(It.IsAny<string>()))
                .Callback(() => counter++)
                .Returns(true).Callback(() => counter++);
            logMock.Object.LogToDb("Sarah");

            Assert.That(counter, Is.EqualTo(7));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            // Verify
            var logMock = new Mock<ILogger>();
            _bankAccount = new BankAccount(logMock.Object);
            _bankAccount.Deposit(100);
            Assert.That(_bankAccount.Balance, Is.EqualTo(100));

            logMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(x => x.Log("Test"), Times.AtLeastOnce);
            logMock.VerifySet(x => x.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(x => x.LogSeverity, Times.Once);
        }
    }
}
