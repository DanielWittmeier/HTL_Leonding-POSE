/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: Intersect UnitTest
*--------------------------------------------------------------
*/

namespace UnitTest;

using FluentAssertions;
using Intersect;
using Xunit;

public class IntersectTests
{
    [Theory]
    [InlineData(new int[] {1}, new int[] {1}, new int[] {1})]
    [InlineData(new int[] {2}, new int[] {1}, new int[0])]
    [InlineData(new int[0], new int[] {1}, new int[0])]
    [InlineData(new int[] {1}, new int[0], new int[0])]
    [InlineData(new int[] {1, 3, 5, 7, 9}, new int[] {0, 1, 2, 3}, new int[] {1, 3})]
    [InlineData(new int[] {1, 3, 5}, new int[] {1, 3, 5}, new int[] {1, 3, 5})]
    [InlineData(new int[] {1, 3, 5, 7, 9}, new int[] {0, 2, 4, 6, 8}, new int[0])]
    [InlineData(new int[] {1, 1, 3, 5, 1, 3}, new int[] {1, 1, 1, 1, 1, 3, 3, 5, 5}, new int[] {1, 3, 5})]
    public void T01_Intersect(int[] a, int[] b, int[] expected)
    {
        IntersectTools.Intersect(a, b).Should().Equal(expected);
    }
}