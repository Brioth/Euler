using Euler;
using Euler.Models;
using NUnit.Framework;

namespace EulerTests
{
    public class Tests
    {
        private Solver _solver;
        private Problem _problem;

        [OneTimeSetUp]
        public void Init()
        {
            _solver = new Solver();
        }

        [SetUp]
        public void Setup()
        {
            _problem = new Problem();
        }

        [Test]
        public void Problem1_ShouldReturn23()
        {
            // Arrange
            _problem.EulerId = 1;
            int[] input = {10};

            // Act
            var result = _solver.Solve(_problem, input);

            // Assert
            Assert.AreEqual(23, result);
        }

        [Test]
        public void Problem2_ShouldReturn()
        {
            // Arrange
            _problem.EulerId = 2;
            int[] input = { 100 };

            // Act
            var result = _solver.Solve(_problem, input);

            // Assert
            Assert.AreEqual(44, result);
        }
    }
}