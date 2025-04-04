/*--------------------------------------------------------------
 *				HTBLA-Leonding / Class: 1xHIF
 *--------------------------------------------------------------
 *              Musterlösung-HA
 *--------------------------------------------------------------
 * Description: Intersect UnitTest
 *--------------------------------------------------------------
 */

using System;
using UnionExcept;

namespace UnitTest;

using FluentAssertions;
using Xunit;

public class SetToolsTests
{
    [Theory]
    [InlineData(new int[] {1}, new int[] {1}, new int[] {1})]
    [InlineData(new int[] {2}, new int[] {1}, new int[] {1, 2})]
    [InlineData(new int[] {0}, new int[] {1}, new int[] {0, 1})]
    [InlineData(new int[0], new int[0], new int[0])]
    [InlineData(new int[0], new int[] {1}, new int[] {1})]
    [InlineData(new int[] {1}, new int[0], new int[] {1})]
    [InlineData(new int[] {1, 3, 5, 7, 9}, new int[] {0, 1, 2, 3}, new int[] {0, 1, 2, 3, 5, 7, 9})]
    [InlineData(new int[] {1, 3, 5}, new int[] {1, 3, 5}, new int[] {1, 3, 5})]
    [InlineData(new int[] {1, 3, 5, 7, 9}, new int[] {0, 2, 4, 6, 8}, new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
    [InlineData(new int[] {1, 1, 3, 5, 1, 3}, new int[] {1, 1, 1, 1, 1, 3, 3, 5, 5}, new int[] {1, 3, 5})]
    public void T01_Union(int[] a, int[] b, int[] expected)
    {
        int[] result = SetTools.Union(a, b);
        Array.Sort(result);
        result.Should().Equal(expected);
    }

    [Theory]
    [InlineData(new int[] {1}, new int[] {1}, new int[0])]
    [InlineData(new int[] {2}, new int[] {1}, new int[] {2})]
    [InlineData(new int[] {2, 0}, new int[] {1}, new int[] {0, 2})]
    [InlineData(new int[0], new int[0], new int[0])]
    [InlineData(new int[0], new int[] {1}, new int[0])]
    [InlineData(new int[] {1}, new int[0], new int[] {1})]
    [InlineData(new int[] {1, 3, 5, 7, 9}, new int[] {0, 1, 2, 3}, new int[] {5, 7, 9})]
    [InlineData(new int[] {1, 3, 5}, new int[] {1, 3, 5}, new int[0])]
    [InlineData(new int[] {1, 3, 5, 7, 9}, new int[] {0, 2, 4, 6, 8}, new int[] {1, 3, 5, 7, 9})]
    [InlineData(new int[] {1, 1, 3, 5, 1, 3}, new int[] {1, 1, 1, 1, 1, 3, 3, 5, 5}, new int[0])]
    public void T02_Except(int[] a, int[] b, int[] expected)
    {
        int[] result = SetTools.Except(a, b);
        Array.Sort(result);
        result.Should().Equal(expected);
    }
}