using C08_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08_MSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoIntegers_GetCorrectAddition()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            int result = calculator.AddNumbers(5, 7);

            // Assert
            Assert.AreEqual(12, result);

        }

        [TestMethod]
        public void SubstractNumbers_InputTwoIntegers_GetCorrectSubstraction()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            int result = calculator.SubstractNumbers(10, 7);

            // Assert
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        public void MultiplyNumbers_InputTwoIntegers_GetCorrectMultiplication()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            int result = calculator.MultiplyNumbers(2, 6);

            // Assert
            Assert.AreEqual(12, result);

        }

        [TestMethod]
        public void DivideNumbers_InputTwoIntegers_GetCorrectDivision()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            double result = calculator.DivideNumbers(5, 2);

            // Assert
            Assert.AreEqual(2.5, result);

        }

        [TestMethod]
        public void ModulusNumbers_InputTwoIntegers_GetCorrectModulus()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            int result = calculator.ModulusNumbers(30, 7);

            // Assert
            Assert.AreEqual(2, result);

        }

        [TestMethod]
        public void ExecuteOperation_InputTwoIntegersAndMultiplyChar_GetCorrectMultiplication()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            double result = calculator.ExecuteOperation(30, 7, '*');

            // Assert
            Assert.AreEqual(210, result);

        }

        [TestMethod]
        public void ExecuteOperation_InputTwoIntegers_GetCorrectModulus()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            double result = calculator.ExecuteOperation(18, 7);

            // Assert
            Assert.AreEqual(4, result);

        }

        [TestMethod]
        public void IsOddNumber_InputOddNumber_GetTrue()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(5);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOddNumber_InputEvenNumber_GetFalse()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            bool result = calculator.IsOddNumber(8);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
