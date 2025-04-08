/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: DameProblem UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest
{
    using FluentAssertions;
    using DameProblem;
    using Xunit;

    public class DameTests
    {
        [Fact]
        public void NoDame()
        {
            bool[,] field = new bool[8, 8]
            {
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false}
            };

            Dame.IsValid(field).Should().BeFalse();
        }

        [Fact]
        public void Solved()
        {
            bool[,] field = new bool[8, 8]
            {
                {false, false, false, false, false, false, false, true},
                {false, false, false, true, false, false, false, false},
                {true, false, false, false, false, false, false, false},
                {false, false, true, false, false, false, false, false},
                {false, false, false, false, false, true, false, false},
                {false, true, false, false, false, false, false, false},
                {false, false, false, false, false, false, true, false},
                {false, false, false, false, true, false, false, false}
            };

            Dame.IsValid(field).Should().BeTrue();
        }

        [Fact]
        public void Solved2()
        {
            bool[,] field = new bool[8, 8]
            {
                {false, false, false, true, false, false, false, false},
                {false, false, false, false, false, true, false, false},
                {false, false, false, false, false, false, false, true},
                {false, true, false, false, false, false, false, false},
                {false, false, false, false, false, false, true, false},
                {true, false, false, false, false, false, false, false},
                {false, false, true, false, false, false, false, false},
                {false, false, false, false, true, false, false, false}
            };

            Dame.IsValid(field).Should().BeTrue();
        }

        [Fact]
        public void FailedRow()
        {
            bool[,] field = new bool[8, 8]
            {
                {false, false, false, false, false, false, false, false},
                {false, false, false, true, false, false, false, true},
                {true, false, false, false, false, false, false, false},
                {false, false, true, false, false, false, false, false},
                {false, false, false, false, false, true, false, false},
                {false, true, false, false, false, false, false, false},
                {false, false, false, false, false, false, true, false},
                {false, false, false, false, true, false, false, false}
            };

            Dame.IsValid(field).Should().BeFalse();
        }

        [Fact]
        public void FailedOneRow()
        {
            bool[,] field = new bool[8, 8]
            {
                {false, false, false, false, false, false, false, false},
                {true, true, true, true, true, true, true, true},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, false, false, false, false},
                {false, false, false, false, true, false, false, false}
            };

            Dame.IsValid(field).Should().BeFalse();
        }

        [Fact]
        public void FailedOneCol()
        {
            bool[,] field = new bool[8, 8]
            {
                {false, true, false, false, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {false, true, false, false, true, false, false, false}
            };

            Dame.IsValid(field).Should().BeFalse();
        }

        [Fact]
        public void FailedDiagLeft()
        {
            bool[,] field = new bool[8, 8]
            {
                {true, false, false, false, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {false, false, true, false, false, false, false, false},
                {false, false, false, true, false, false, false, false},
                {false, false, false, false, true, false, false, false},
                {false, false, false, false, false, true, false, false},
                {false, false, false, false, false, false, true, false},
                {false, false, false, false, true, false, false, true}
            };

            Dame.IsValid(field).Should().BeFalse();
        }

        [Fact]
        public void FailedDiagRight()
        {
            bool[,] field = new bool[8, 8]
            {
                {false, false, false, false, false, false, false, true},
                {false, false, false, false, false, false, true, false},
                {false, false, false, false, false, true, false, false},
                {false, false, false, false, true, false, false, false},
                {false, false, false, true, false, false, false, false},
                {false, false, true, false, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {true, false, false, false, false, false, false, false}
            };

            Dame.IsValid(field).Should().BeFalse();
        }

        [Fact]
        public void FailedCol()
        {
            bool[,] field = new bool[8, 8]
            {
                {false, false, false, false, false, false, false, true},
                {false, false, false, true, false, false, false, false},
                {false, true, false, false, false, false, false, false},
                {false, false, true, false, false, false, false, false},
                {false, false, false, false, false, true, false, false},
                {false, true, false, false, false, false, false, false},
                {false, false, false, false, false, false, true, false},
                {false, false, false, false, true, false, false, false}
            };

            Dame.IsValid(field).Should().BeFalse();
        }
    }
}