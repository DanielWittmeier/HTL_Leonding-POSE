/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung
*--------------------------------------------------------------
* Description: Gomoku
*--------------------------------------------------------------
*/

namespace Gomoku;

using System;
using System.IO;

public static class Gomoku
{
    public const string _fileName = "game.csv";

    /// <summary>
    ///     Executes the Gomoku program
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Gomoku ");
        Console.WriteLine("=========");

        //TODO: Implement main gomoku method
    }

    /// <summary>
    /// Set a stone on the (game-)field.
    /// Row and col must be a empty position.
    /// </summary>
    /// <param name="field">The game field</param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="player">The player (0,1= who set the stone</param>
    /// <returns>true, if the user won the game, false otherwise</returns>
    public static bool SetStone(int[,] field, int row, int col, int player)
    {
        //TODO Implement SetStone
        throw new NotImplementedException();
    }

    /// <summary>
    /// Check, if after placing a stone, the player has won the game.
    /// Do not check all fields, only the surrounding fields of the new stone.
    /// </summary>
    /// <param name="field"></param>
    /// <param name="row">Row of the new stone.</param>
    /// <param name="col">Column of the new stone</param>
    /// <returns>true if 5 in any directions</returns>
    public static bool IsWinner(int[,] field, int row, int col)
    {
        //TODO Implement IsWinner
        throw new NotImplementedException();
    }

    /// <summary>
    /// Count all stones on the field, independent of the player.
    /// </summary>
    /// <param name="field"></param>
    /// <returns>Count of stones on the field</returns>
    public static int GetStoneCount(int[,] field)
    {
        //TODO Implement GetStoneCount
        throw new NotImplementedException();
    }

    /// <summary>
    /// Save the current game to the specified file (as excel csv).
    /// </summary>
    /// <param name="field">the definition for the current game.</param>
    /// <param name="fileName">The destination filename.</param>
    public static void SaveGame(int[,] field, string fileName)
    {
        //TODO Implement SaveGame
        throw new NotImplementedException();
    }

    /// <summary>
    /// Load a stored game from a file (csv format).
    /// The file must be in a correct format (no validation check)
    /// and the boardSize must match.
    /// Errors are ignored
    /// </summary>
    /// <param name="boardSize">16,17 or 19</param>
    /// <param name="fileName">Source file-name.</param>
    /// <returns></returns>
    public static int[,] LoadGame(int boardSize, string fileName)
    {
        //TODO Implement LoadGame
        throw new NotImplementedException();
    }
}