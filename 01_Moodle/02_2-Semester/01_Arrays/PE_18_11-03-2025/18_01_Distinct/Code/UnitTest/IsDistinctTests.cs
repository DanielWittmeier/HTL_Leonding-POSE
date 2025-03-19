/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: (Array-)Distinct UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;
    using Xunit;
    using Distinct;

    public class IsDistinctTests
    {
        [Fact]
        public void T01_IsDistinctEmpty()
        {
            var ar = new int[0];

            DistinctTools.IsDistinct(ar).Should().BeTrue();
        }

        [Fact]
        public void T02_IsDistinctOne()
        {
            var ar = new int[] {-1};

            DistinctTools.IsDistinct(ar).Should().BeTrue();
        }

        [Fact]
        public void T03_IsDistinctAllEqual()
        {
            var ar = new int[] {1, 1, 1, 1, 1, 1};

            DistinctTools.IsDistinct(ar).Should().BeFalse();
        }

        [Theory]
        [InlineData(new int[] {1, 1})]
        [InlineData(new int[] {1, 2, 1})]
        [InlineData(new int[] {1, 2, 2})]
        [InlineData(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 1})]
        public void T04_IsNotDistinct(int[] ar)
        {
            DistinctTools.IsDistinct(ar).Should().BeFalse();
        }

        [Theory]
        [InlineData(new int[] {1})]
        [InlineData(new int[] {1, 2})]
        [InlineData(new int[] {1000, 2000, -1000, -2000})]
        public void T04_IstDistinct(int[] ar)
        {
            DistinctTools.IsDistinct(ar).Should().BeTrue();
        }
    }
}