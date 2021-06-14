using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorLibraryTests
{
    [TestClass]
    public class CalculatorLibraryTests
    {
        [TestMethod]
        public void CalculateExpession_Null()
            => Assert.ThrowsException<ArgumentException>(() => CalculatorLibrary.Calculator.CalculateExpession(null));

        [TestMethod]
        public void CalculateExpession_EmptyString()
            => Assert.ThrowsException<ArgumentException>(() => CalculatorLibrary.Calculator.CalculateExpession(String.Empty));

        [TestMethod]
        public void CalculateExpession_OneOperation()
            => Assert.ThrowsException<InvalidOperationException>(() => CalculatorLibrary.Calculator.CalculateExpession("+"));

        [TestMethod]
        public void CalculateExpession_OneOperationAndOneArgument()
            => Assert.ThrowsException<InvalidOperationException>(() => CalculatorLibrary.Calculator.CalculateExpession("+ 5"));

        [TestMethod]
        public void CalculateExpession_CharArgument()
            => Assert.ThrowsException<FormatException>(() => CalculatorLibrary.Calculator.CalculateExpession("+ 5 f"));

        [TestMethod]
        public void CalculateExpession_Addition()
        {
            int expected = 5;
            int actual = CalculatorLibrary.Calculator.CalculateExpession("+ 2 3");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExpession_Subtraction()
        {
            int expected = 3;
            int actual = CalculatorLibrary.Calculator.CalculateExpession("- 5 2");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExpession_Multiplication()
        {
            int expected = 6;
            int actual = CalculatorLibrary.Calculator.CalculateExpession("* 2 3");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExpession_Division()
        {
            int expected = 4;
            int actual = CalculatorLibrary.Calculator.CalculateExpession("/ 8 2");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExpession_AdditionAndMultiplication()
        {
            int expected = 7;
            int actual = CalculatorLibrary.Calculator.CalculateExpession("+ * 2 3 1");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateExpession_SubtractionAndDivision()
        {
            int expected = 1;
            int actual = CalculatorLibrary.Calculator.CalculateExpession("/ - 3 1 2");
            Assert.AreEqual(expected, actual);
        }
    }
}
