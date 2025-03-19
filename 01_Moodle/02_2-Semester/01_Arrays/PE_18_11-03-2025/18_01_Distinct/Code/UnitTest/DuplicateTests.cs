/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: (Array-)Duplicate UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;
    using Xunit;
    using Distinct;

    public class DuplicateTests
    {
        [Fact]
        public void T01_DuplicateEmpty()
        {
            var ar = new int[0];

            DistinctTools.Duplicate(ar).Should().BeEmpty();
        }

        [Fact]
        public void T02_DuplicateOne()
        {
            var ar = new int[] {-1};

            DistinctTools.Duplicate(ar).Should().BeEmpty();
        }

        [Fact]
        public void T03_DuplicateAllEqual()
        {
            var ar = new int[] {1, 1, 1, 1, 1, 1};

            DistinctTools.Duplicate(ar).Should().BeEquivalentTo(new[] {1});
        }

        [Theory]
        [InlineData(new int[] {1, 1}, new int[] {1})]
        [InlineData(new int[] {1, 2, 1}, new int[] {1})]
        [InlineData(new int[] {1, 2, 2}, new int[] {2})]
        [InlineData(new int[] {1, 2, 3, 4, 1, 6, 7, 8, 9, 1, 9}, new int[] {1, 9})]
        [InlineData(new int[] {1, 2, 3, 4, 5, 1, 2, 3, 4, 5}, new int[] {1, 2, 3, 4, 5})]
        public void T04_Duplicate(int[] ar, int[] expected)
        {
            DistinctTools.Duplicate(ar).Should().BeEquivalentTo(expected);
        }
    }
}