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

    public class DistinctTests
    {
        [Fact]
        public void T01_DistinctEmpty()
        {
            var ar = new int[0];

            DistinctTools.Distinct(ar).Should().BeEmpty();
        }

        [Fact]
        public void T02_DistinctOne()
        {
            var ar = new int[] {-1};

            DistinctTools.Distinct(ar).Should().Equal(ar);
        }

        [Fact]
        public void T03_DistinctAllEqual()
        {
            var ar = new int[] {1, 1, 1, 1, 1, 1};

            DistinctTools.Distinct(ar).Should().BeEquivalentTo(new[] {1});
        }

        [Theory]
        [InlineData(new int[] {1, 1}, new int[] {1})]
        [InlineData(new int[] {1, 2, 1}, new int[] {1, 2})]
        [InlineData(new int[] {1, 2, 2}, new int[] {1, 2})]
        [InlineData(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 1}, new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
        [InlineData(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9})]
        public void T04_Distinct(int[] ar, int[] expected)
        {
            DistinctTools.Distinct(ar).Should().BeEquivalentTo(expected);
        }
    }
}