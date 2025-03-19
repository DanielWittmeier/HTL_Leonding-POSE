/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: linear Interpolation
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;
    using Xunit;
    using LinearInterpolation;

    public class InterpolationTest
    {
        [Theory]
        [InlineData(450.0, 25.73, 0.01)]
        [InlineData(400.01, 25.2, 0.01)]
        [InlineData(399.99, 25.2, 0.01)]
        [InlineData(400.00, 25.2, 0.000000000001)]
        [InlineData(10.0, 5.2, 0.000000000001)]
        [InlineData(1000.0, 32.9, 0.000000000001)]
        [InlineData(9.99, 5.2, 0.000000000001)]
        [InlineData(1000.01, 32.9, 0.000000000001)]
        [InlineData(0, 5.2, 0.000000000001)]
        [InlineData(1024, 32.9, 0.000000000001)]
        public void T01_CalculateYSorted(double actual, double expected, double precision)
        {
            var xValues = new[] {10.0, 400.0, 900.0, 1000.0};
            var yValues = new[] {5.2, 25.2, 30.5, 32.9};
            LinearInterpolationTools.Calculate(actual, xValues, yValues).Should().BeApproximately(expected, precision);
        }

        [Theory]
        [InlineData(450.0, 25.73, 0.01)]
        [InlineData(400.01, 25.2, 0.01)]
        [InlineData(399.99, 25.2, 0.01)]
        [InlineData(400.00, 25.2, 0.000000000001)]
        [InlineData(10.0, 5.2, 0.000000000001)]
        [InlineData(1000.0, 32.9, 0.000000000001)]
        [InlineData(9.99, 5.2, 0.000000000001)]
        [InlineData(1000.01, 32.9, 0.000000000001)]
        [InlineData(0, 5.2, 0.000000000001)]
        [InlineData(1024, 32.9, 0.000000000001)]
        public void T02_CalculateYUnsorted(double actual, double expected, double precision)
        {
            var xValues = new[] {400.0, 10.0, 1000.0, 900.0};
            var yValues = new[] {25.2, 5.2, 32.9, 30.5};
            LinearInterpolationTools.Calculate(actual, xValues, yValues).Should().BeApproximately(expected, precision);
        }

        [Fact]
        public void T03_IllegalEmpty()
        {
            var xValues = new double[0];
            var yValues = new double[0];
            LinearInterpolationTools.Calculate(3, xValues, yValues).Should().Be(0.0);
        }

        [Fact]
        public void T03_IllegalWrongSize()
        {
            var xValues = new[] { 400.0, 10.0, 1000.0, 900.0, 3.14 };
            var yValues = new[] { 25.2, 5.2, 32.9, 30.5 };
            LinearInterpolationTools.Calculate(450, xValues, yValues).Should().Be(0.0);
        }
    }
}