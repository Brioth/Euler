using Euler.Logic;
using NUnit.Framework;
using System.Collections.Generic;

namespace EulerTests
{
    [TestFixture]
    public class MathHelperTests
    {
        [Test]
        public void CreateFibonacci_ShouldCreateFibonacciSequence()
        {
            // Arrange
            var expected = new List<int>() { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };

            // Act
            var result = MathHelper.CreateFibonacci(10);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CreateFibonacciWitMaxValue_ShouldCreateFibonacciSequence()
        {
            // Arrange
            var expected = new List<int>() { 1, 2, 3, 5, 8 };

            // Act
            var result = MathHelper.CreateFibonacciWithMaxValue(10);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
