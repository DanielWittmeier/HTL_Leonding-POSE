/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: Gomoku
*--------------------------------------------------------------
*/

namespace UnitTests;

using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Gomoku;

using UnitTest;

using Xunit;

public sealed class GomokuTests
{
    [Fact]
    public void CheckWinner()
    {
        // field with 5 in row,col and both diag
        var field = new int[,]
        {
            {-1,-1,-1, 0,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1, 0,-1, 1,-1,-1,-1,-1 },
            {-1,-1,-1, 0,-1,-1, 1,-1,-1,-1 },
            {-1,-1,-1, 0,-1,-1,-1, 1,-1,-1 },
            { 0,-1,-1, 0,-1,-1,-1,-1, 1,-1 },
            {-1, 0,-1,-1,-1,-1,-1,-1,-1, 1 },
            {-1,-1, 0,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1, 0,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1,-1, 0,-1,-1,-1,-1,-1 },
            {-1, 1, 1, 1, 1, 1,-1,-1,-1,-1 },
        };

        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                if (field[row, col] != -1)
                {
                    Gomoku.IsWinner(field, row, col).Should().BeTrue();
                }
            }
        }
    }

    [Fact]
    public void CheckNoWinner()
    {
        // field with only 4 in row,col and both diag
        var field = new int[,]
        {
            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1, 0,-1, 1,-1,-1,-1,-1 },
            {-1,-1,-1, 0,-1,-1, 1,-1,-1,-1 },
            {-1,-1,-1, 0,-1,-1,-1, 1,-1,-1 },
            {-1,-1,-1, 0,-1,-1,-1,-1, 1,-1 },
            {-1, 0,-1,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1, 0,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1, 0,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1,-1, 0,-1,-1,-1,-1,-1 },
            {-1,-1, 1, 1, 1, 1,-1,-1,-1,-1 },
        };

        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                if (field[row, col] != -1)
                {
                    Gomoku.IsWinner(field, row, col).Should().BeFalse();
                }
            }
        }
    }

    [Fact]
    public void SaveAndLoadGameEmpty()
    {
        var fileName = "TestGomoku.csv";
        var field    = InitEmptyField(15, 15);
        Gomoku.SaveGame(field, fileName);
        field.Should().BeEquivalentTo(InitEmptyField(15, 15), "save must not change field");
        Gomoku.LoadGame(15, fileName).Should().BeEquivalentTo(field);
    }

    [Fact]
    public void SaveAndLoadGame()
    {
        var fileName   = "TestGomoku.csv";
        var field      = InitAGame();
        var fieldSaved = (int[,])field.Clone();

        Gomoku.SaveGame(field, fileName);

        var csvImport   = new CsvImport<SavedGame>();
        var csvExported = csvImport.Read(fileName);

        csvExported.Should().HaveCount(Gomoku.GetStoneCount(field));

        field.Should().BeEquivalentTo(fieldSaved, "save must not change field");
        Gomoku.LoadGame(15, fileName).Should().BeEquivalentTo(field);
    }

    [Fact]
    public void CheckCsvFormat()
    {
        var fileName   = "SavedGame.csv";

        var csvImport = new CsvImport<SavedGame>();
        var importField = csvImport.Read(fileName);
        var loadField = Gomoku.LoadGame(15, fileName);

        importField.Should().HaveCount(Gomoku.GetStoneCount(loadField));

        foreach (var savedGame in importField)
        {
            loadField[savedGame.Row, savedGame.Col].Should().Be(savedGame.Player);
        }
    }
    [Fact]
    public void GetStoneCountEmpty()
    {
        var field = InitEmptyField(19, 19);
        Gomoku.GetStoneCount(field).Should().Be(0);
    }

    [Fact]
    public void GetStoneCount()
    {
        var field = InitAGame();
        Gomoku.GetStoneCount(field).Should().Be(Stones.Count());
    }

    [Fact]
    public void SetStoneCountEmpty()
    {
        var field = InitEmptyField(19, 19);
        Gomoku.GetStoneCount(field).Should().Be(0);
    }

    [Fact]
    public void SetStone()
    {
        var stones = Stones.ToList();
        var field  = InitAGame(stones);

        foreach (var stone in stones)
        {
            field[stone.Row, stone.Col].Should().Be(stone.Player);
        }

        Gomoku.GetStoneCount(field).Should().Be(stones.Count);
    }

    private static IEnumerable<(int Row, int Col, int Player)> Stones => new List<(int Row, int Col, int Player)>
    {
        (0, 0, 0),
        (1, 1, 1),
        (2, 2, 0),
        (3, 3, 1),
        (4, 4, 0),
        (5, 5, 1),
    };

    private void SetStones(int[,] field, IEnumerable<(int Row, int Col, int Player)> stones)
    {
        foreach (var stone in stones)
        {
            Gomoku.SetStone(field, stone.Row, stone.Col, stone.Player);
        }
    }

    private int[,] InitAGame(IEnumerable<(int Row, int Col, int Player)> stones=null)
    {
        var field = InitEmptyField(15, 15);
        SetStones(field, stones ?? Stones);
        return field;
    }

    private static int[,] InitEmptyField(int rows, int cols)
    {
        var field = new int[rows, cols];

        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                field[row, col] = -1;
            }
        }

        return field;
    }
}