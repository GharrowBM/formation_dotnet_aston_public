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
    public class CalculatorNUnitTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }

        [Test]
        public void AddNumbers_InputTwoIntegers_GetCorrectAddition()
        {

            // Act
            int result = _calculator.AddNumbers(5, 7);

            // Assert
            Assert.AreEqual(12, result);

        }

        [Test]
        public void SubstractNumbers_InputTwoIntegers_GetCorrectSubstraction()
        {

            // Act
            int result = _calculator.SubstractNumbers(10, 7);

            // Assert
            Assert.AreEqual(3, result);

        }

        [Test]
        public void MultiplyNumbers_InputTwoIntegers_GetCorrectMultiplication()
        {

            // Act
            int result = _calculator.MultiplyNumbers(2, 6);

            // Assert
            Assert.AreEqual(12, result);

        }

        [Test]
        public void DivideNumbers_InputTwoIntegers_GetCorrectDivision()
        {

            // Act
            double result = _calculator.DivideNumbers(5, 2);

            // Assert
            Assert.AreEqual(2.5, result);

        }

        [Test]
        public void ModulusNumbers_InputTwoIntegers_GetCorrectModulus()
        {

            // Act
            int result = _calculator.ModulusNumbers(30, 7);

            // Assert
            Assert.AreEqual(2, result);

        }

        [Test]
        public void ExecuteOperation_InputTwoIntegersAndMultiplyChar_GetCorrectMultiplication()
        {

            // Act
            double result = _calculator.ExecuteOperation(30, 7, '*');

            // Assert
            Assert.AreEqual(210, result);

        }

        [Test]
        public void ExecuteOperation_InputTwoIntegers_GetCorrectModulus()
        {

            // Act
            double result = _calculator.ExecuteOperation(18, 7);

            // Assert
            Assert.AreEqual(4, result);

        }

        [Test]
        [TestCase(12)]
        [TestCase(14)]
        public void IsOddNumber_InputEvenNumber_GetFalse(int nbA)
        {

            // Act
            bool result = _calculator.IsOddNumber(nbA);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(11, ExpectedResult = true)]
        [TestCase(12, ExpectedResult = false)]
        public bool IsOddNumber_InputNumber_GetTrueIfOdd(int nbA)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            return calculator.IsOddNumber(nbA);
        }

        [Test]
        [TestCase(5.4, 10.5)]
        [TestCase(5.43, 10.53)]
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double dbA, double dbB)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            double result = calculator.AddNumbersDouble(dbA, dbB);

            // Assert
            Assert.AreEqual(15.9, result, .1);
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ResturnsValidNumberRange()
        {
            // Arrange
            Calculator calculator = new();
            List<int> expectedOddRange = new() { 5, 7, 9 };

            // Act
            List<int> result = calculator.GetOddRange(5, 10);

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.AreEqual(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered.Ascending);
            Assert.That(result, Is.Unique);
        }
    }
}
