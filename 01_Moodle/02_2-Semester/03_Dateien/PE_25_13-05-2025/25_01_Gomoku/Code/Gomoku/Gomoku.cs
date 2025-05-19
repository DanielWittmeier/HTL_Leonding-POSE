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
using System.Windows.Forms;

public static class Gomoku
{
    public const string _fileName = "game.csv";

    /// <summary>
    ///     Executes the Gomoku program
    /// </summary>
    public static void Run()
    {
        string input;
        string[] playerchoose;
        Console.WriteLine("Gomoku ");
        Console.WriteLine("=========");

        int boardSize = Tools.DefineBoardSize("Board size [15,17 or 19]: ", [15,17,19]);
        Console.WriteLine("\"row,col\" to set stone, e.g. 5,7");
        Console.WriteLine("! to resign game (quit program)");
        Console.WriteLine("s to save the game (and continue)");
        Console.WriteLine("l resign the current game and load the store game - continue with the stored game.");
        int currentPlayer = 0;

        Board.Init(boardSize, boardSize, "Gomoku");

        int[,] board = new int[boardSize, boardSize];
        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                board[x, y] = -1;
            }
        }

        do
        {
            Console.Write($"Player {currentPlayer+1}: ");
            input = Console.ReadLine()!;

            if (input == "!") { }
            else if ( input == "s")
            {
                Console.WriteLine("Code zum speichern fehlt noch");
            }
            else if ( input == "l")
            {
                Console.WriteLine("Code zum laden fehlt noch");
            }
            else
            {
                playerchoose = input.Split(",");
                if ( playerchoose.Length != 2 )
                {
                    Console.WriteLine("Ungültige Eingabe!");
                }
                else
                {
                    if (!int.TryParse(playerchoose[0], out int value1) || !int.TryParse(playerchoose[1], out int value2))
                    {
                        Console.WriteLine("Ungültige Eingabe!");
                    }
                    else
                    {
                        if (value1 > boardSize || value2 > boardSize )
                        {
                            Console.WriteLine("Eingabe außerhalb des Boards!");
                        }
                        else
                        {
                            if (board[value1,value2] != -1)
                            {
                                Console.WriteLine("Feld ist bereits belegt!");
                            }
                            else
                            {
                                board[value1, value2] = currentPlayer;
                                SetStone(board, value1, value2, currentPlayer);
                                if ( currentPlayer == 1)
                                {
                                    currentPlayer = 0;
                                }
                                else
                                {
                                    currentPlayer++;
                                }

                            }
                        }
                    }
                }

            }

              
        } while (input != "!");

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
        if ( player == 0)
        {
            Board.SetText(row, col, "X","Red");
        }
        else if ( player == 1)
        {
            Board.SetText(row, col, "O", "Green");
        }

        return false;
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
        int player = field[row, col];
        bool isTrue = false;
        int anzahl = 1;
        int x = row - 1;
        int y = col;
        do
        {
            isTrue = false;
            if (field[x, y] == player)
            {
                isTrue = true;
                anzahl++;
                x--;
            }
            if (anzahl == 5)
            {
                return true;
            }
        } while (isTrue);
    }

    /// <summary>
    /// Count all stones on the field, independent of the player.
    /// </summary>
    /// <param name="field"></param>
    /// <returns>Count of stones on the field</returns>
    public static int GetStoneCount(int[,] field)
    {
        int value = 0;
        for (int x = 0; x < field.GetLength(0); x++)
        {
            for (int y = 0; y < field.GetLength(1); y++)
            {
                if ( field[x, y] > -1 )
                {
                    value++;
                } 
            }
        }
        return value;
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