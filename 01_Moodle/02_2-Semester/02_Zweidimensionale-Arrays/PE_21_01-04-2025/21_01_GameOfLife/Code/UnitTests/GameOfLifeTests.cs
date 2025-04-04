/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: GameOfLife
* see: https://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens
*--------------------------------------------------------------
*/

using FluentAssertions;
using Xunit;

namespace UnitTest
{
    public class GameOfLifeTests
    {
        private bool[,] World() => new bool[,]
        {
            {false, false, false, true},
            {false, false, false, true},
            {true, true, true, true},
            {true, true, false, false}
        };

        [Theory]
        [InlineData(1, 1, 3)]
        [InlineData(1, 2, 5)]
        [InlineData(2, 1, 4)]
        [InlineData(2, 2, 4)]
        public void T01_CountNeighboursTestMiddle(int row, int col, int expected)
        {
            GameOfLife.GameOfLife.CountNeighbours(World(), row, col).Should().Be(expected);
            ;
        }

        [Theory]
        [InlineData(0, 0, 4)]
        [InlineData(0, 3, 2)]
        [InlineData(3, 0, 5)]
        [InlineData(3, 3, 5)]
        public void T02_CountNeighboursTestCorner(int row, int col, int expected)
        {
            GameOfLife.GameOfLife.CountNeighbours(World(), row, col).Should().Be(expected);
            ;
        }

        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(2, 0, 5)]
        [InlineData(3, 2, 5)]
        [InlineData(2, 3, 4)]
        public void T03_CountNeighboursTestBorder(int row, int col, int expected)
        {
            GameOfLife.GameOfLife.CountNeighbours(World(), row, col).Should().Be(expected);
            ;
        }

        [Fact]
        public void T04_NextGeneration()
        {
            var world = World();
            var gen1 = new[,]
            {
                {false, false, true, true},
                {false, true, false, false},
                {false, false, false, false},
                {false, false, false, false}
            };

            var gen2 = new[,]
            {
                {false, false, true, false},
                {false, false, true, false},
                {false, false, false, false},
                {false, false, false, false}
            };

            GameOfLife.GameOfLife.CalculateNextGeneration(world).Should().BeEquivalentTo(gen1,
                options => options.ComparingByValue<bool>());

            GameOfLife.GameOfLife.CalculateNextGeneration(gen1).Should().BeEquivalentTo(gen2,
                options => options.ComparingByValue<bool>());
        }
    }
}