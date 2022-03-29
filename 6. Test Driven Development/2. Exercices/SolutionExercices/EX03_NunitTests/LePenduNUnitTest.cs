using EX03_Classes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03_NunitTests
{
    [TestFixture]
    public class LePenduNUnitTest
    {
        private LePendu _pendu;

        [SetUp]
        public void Setup()
        {
            _pendu = new LePendu();
            var generateur = new Mock<IGenerateur>();
            generateur.Setup(p => p.Generer()).Returns("toto");
            _pendu.GenererMasque(generateur.Object);
        }

        [Test]
        public void GenererMasqueTest()
        {
            Assert.That(_pendu.Masque, Is.EqualTo("****"));
        }

        [Test]
        public void TestChar_InputValidChar_ReturnTrue()
        {
            var result = _pendu.TestChar('t');

            Assert.IsTrue(result);
        }

        [Test]
        public void TestChar_InputInvalidChar_ReturnFalse()
        {
            var result = _pendu.TestChar('i');

            Assert.IsFalse(result);
        }

        [Test]
        public void NbEssaiChecker_InputValidChar_ShouldStaySame()
        {
            _pendu.TestChar('t');

            Assert.That(_pendu.NbEssai, Is.EqualTo(10));
        }

        [Test]
        public void NbEssaiChecker_InputInvalidChar_ShouldDecrease()
        {
            _pendu.TestChar('i');

            Assert.That(_pendu.NbEssai, Is.EqualTo(9));
        }

        [Test]
        public void MasqueChecker_InputValidChar_ShouldChange()
        {
            _pendu.TestChar('t');

            Assert.That(_pendu.Masque, Is.EqualTo("t*t*"));
        }

        [Test]
        public void MasqueChecker_InputInvalidChar_ShouldNotChange()
        {
            _pendu.TestChar('b');

            Assert.That(_pendu.Masque, Is.EqualTo("****"));
        }

        [Test]
        public void TestWin_WinningScenario_ReturnTrue()
        {
            _pendu.TestChar('t');
            _pendu.TestChar('o');

            Assert.IsTrue(_pendu.TestWin());
        }

        [Test]
        public void TestWin_LosingScenario_ReturnFalse()
        {
            _pendu.TestChar('i');

            Assert.IsFalse(_pendu.TestWin());
        }

        [Test]
        public void TestWin_LosingScenarioFromTooManyAttemps_ReturnFalse()
        {
            for (int i = 1; i <= 10; i++) _pendu.TestChar('i');
            _pendu.TestChar('t');
            _pendu.TestChar('o');

            Assert.IsFalse(_pendu.TestWin());
        }
    }
}
