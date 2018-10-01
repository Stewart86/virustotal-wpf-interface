using System;
using Xunit;

namespace CustodioUIApp.UnitTests
{
    public class WaysToClimb
    {
        [Fact]
        public void TestMaxNumber()
        {
            // Arrange
            int expected = 2147476773;

            // Action
            int actual = Calculate.WaysToClimb(75675);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNaturalNumber()
        {
            // Arrange
            int expected = 3;

            // Action
            int actual = Calculate.WaysToClimb(3);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNegativeInputRaiseError()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Calculate.WaysToClimb(-9));
        }

        [Fact]
        public void TestRaiseDivisinByZeroError()
        {
            Assert.Throws<DivideByZeroException>(() => Calculate.WaysToClimb(0));
        }

        [Fact]
        public void TestRaiseOverflowWhenMaxInputError()
        {
            Assert.Throws<OverflowException>(() => Calculate.WaysToClimb(75676));
        }

        [Fact]
        public void TestSimpleNumber()
        {
            // Arrange
            int expected = 47;

            // Action
            int actual = Calculate.WaysToClimb(12);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}