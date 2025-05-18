// HTL Leonding utility class for providing a simple playing field
// !!! Do NOT change anything in this file !!!

#region Board code - do not change

using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

public delegate void CellClickHandler(int row, int col);

/// <summary>
///     Zugriffsklasse auf das Windows-Board
/// </summary>
public class Board
{
    private static   bool      _boardInitialized; // Ist das Board bereits initialisiert
    private static   Board     _staticBoard = default!;
    private readonly int       _cols;
    private          FormBoard _form; // WindowsForm zur Darstellung in zweitem Thread
    private readonly int       _rows;
    private          string    _title;

    public static event CellClickHandler? CellClicked;

    /// <summary>
    ///     Spielfeld mit _rows/_cols anlegen
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="cols"></param>
    private Board(int rows, int cols)
    {
        _rows  = rows;
        _cols  = cols;
        _title = "Board";
        _form  = default!;
    }


    /// <summary>
    ///     Titel des Spielfeldes lesen
    /// </summary>
    public static string Title => _staticBoard._title;

    /// <summary>
    ///     Das Board wird in der gewünschten Größe initialisiert.
    /// </summary>
    /// <param name="rows">Anzahl der gewünschten Zeilen</param>
    /// <param name="cols">Anzahl der Spalten</param>
    /// <param name="title">Text in Titelleiste</param>
    public static void Init(int rows, int cols, string title)
    {
        _boardInitialized = false;
        if (rows < 0)
        {
            rows = 0;
        }

        if (cols < 0)
        {
            cols = 0;
        }

        _staticBoard = new(rows, cols) { _title = title };
        Thread formThread = new(Run) { IsBackground = true };
        formThread.Start();
        while (!_boardInitialized) // Warten, bis das Board fertig initialisiert ist
        {
            Thread.Sleep(100);
        }
    }

    /// <summary>
    ///     Board schließen ==> Windows-Anwendung schließen
    /// </summary>
    public static void Exit()
    {
        Application.Exit();
    }

    /// <summary>
    ///     Die Methode Run startet das Zeichenfenster unter einem eigenen Thread. Dadurch wird eine
    ///     Entkoppelung von der eigentlichen Anwendung erreicht.
    /// </summary>
    private static void Run()
    {
        _staticBoard._form = new(_staticBoard._rows, _staticBoard._cols, _staticBoard._title);
        _boardInitialized  = true;
        Application.Run(_staticBoard._form);
    }

    /// <summary>
    ///     Possible colors: Red, Green, Black, LightGrey
    /// </summary>
    public static void SetText(int row, int col, string text, string color)
    {
        if (_staticBoard == null || row < 0 || row >= _staticBoard._rows || col < 0 || col >= _staticBoard._cols)
        {
            return;
        }

        _staticBoard._form.SetText(row, col, text, color);
    }

    /// <summary>
    ///     Text im Board setzen.
    /// </summary>
    public static void SetText(int row, int col, string text)
    {
        SetText(row, col, text, "Black");
    }

    /// <summary>
    ///     Text aus dem Board zurücklesen
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns>String der jeweiligen Zelle</returns>
    public static string GetText(int row, int col)
    {
        if (row < 0 || row >= _staticBoard._rows || col < 0 || col >= _staticBoard._cols)
        {
            return null!;
        }

        return _staticBoard._form.GetText(row, col);
    }

    /// <summary>
    ///     Inhalte des Boards löschen
    /// </summary>
    public static void Clear()
    {
        for (var i = 0; i < _staticBoard._rows; i++)
        {
            for (var j = 0; j < _staticBoard._cols; j++)
            {
                SetText(i, j, "");
            }
        }
    }

    /// <summary>
    ///     Entsprechend der Methode GetLength bei Arrays kann auch hier
    ///     die Dimension des Boards (0=>Zeilen, 1=>Spalten) abgefragt werden.
    /// </summary>
    /// <param name="dimension"></param>
    /// <returns></returns>
    public static int GetLength(int dimension)
    {
        return dimension switch
        {
            < 0 or >= 2 => -1,
            0           => _staticBoard._rows,
            _           => _staticBoard._cols
        };
    }

    public static void OnCellClicked(int row, int col)
    {
        CellClicked?.Invoke(row, col);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern short GetKeyState(int keyCode);

    public const int KEY_PRESSED = 0x8000;

    public static bool IsKeyDown(Keys key)

    {
        return Convert.ToBoolean(GetKeyState((int)key) & KEY_PRESSED);
    }

    public static bool IsShiftKeyDown()
    {
        return IsKeyDown((Keys)0x10); // see https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    }

    public static bool IsCtrlKeyDown()
    {
        return IsKeyDown((Keys)0x11); // see https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    }

    public static bool IsAltKeyDown()
    {
        return IsKeyDown((Keys)0x12); // see https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    }
}


/// <summary>
///     WindowsBoard wird in einem zweiten Thread gestartet.
///     Der Zugriff auf die Elemente erfolgt über Invoke im Kontext des Windows-Threads
/// </summary>
public class FormBoard : Form
{
    private const    int        CELL_HEIGHT = 22;
    private const    int        CELL_WIDTH  = 22;
    private readonly int        _cols;
    private readonly int        _rows;
    private          TextBox[,] _board             = default!;
    private          TextBox[]  _columnHeader      = default!;
    private          Panel      _panelAll          = default!;
    private          Panel      _panelBoard        = default!;
    private          Panel      _panelColumnHeader = default!; // null ==> existiert noch nicht
    private          Panel      _panelRowHeader    = default!;
    private          TextBox[]  _rowHeader         = default!;


    /// <summary>
    ///     Required designer variable.
    /// </summary>
    private IContainer components = null!;

    public FormBoard(int rows, int cols, string title)
    {
        _rows = rows;
        _cols = cols;
        InitializeComponent();
        Text = title;
    }

    [AllowNull]
    public override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    /// <summary>
    ///     Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    /// <summary>
    ///     Textboxen programmgesteuert auf dem Panel positionieren
    /// </summary>
    private void InitializeComponent()
    {
        components        = new Container();
        AutoScaleMode     = AutoScaleMode.Font;
        Text              = "FormBoard";
        AutoScaleBaseSize = new(5, 13);
        ClientSize        = new(292, 266);
        ControlBox        = false;
        FormBorderStyle   = FormBorderStyle.FixedSingle;
        Location          = new(600, 200);
        Name              = "FormBoard";
        Text              = "FormBoard";
        _board            = new TextBox[_rows, _cols];
        _panelAll         = new();
        Controls.Add(_panelAll);
        _panelBoard = new()
        {
            Width  = _cols * CELL_WIDTH + 10,
            Height = _rows * CELL_HEIGHT + 10
        };
        _panelAll.Controls.Add(_panelBoard);
        TextBox textBox;
        // ColumnHeader
        _panelColumnHeader        = new();
        _columnHeader             = new TextBox[_cols];
        _panelColumnHeader.Height = CELL_HEIGHT;
        _panelColumnHeader.Width  = _cols * CELL_WIDTH;
        for (var col = 0; col < _cols; col++)
        {
            textBox            = CreateTextBox(Color.SkyBlue, col.ToString());
            _columnHeader[col] = textBox;
            textBox.Location   = new(col * CELL_WIDTH, 0);
            _panelColumnHeader.Controls.Add(textBox);
        }

        _panelAll.Controls.Add(_panelColumnHeader);
        _panelColumnHeader.Location = new(CELL_WIDTH, 0);
        // Row-Header
        _panelRowHeader        = new();
        _panelRowHeader.Height = _rows * CELL_HEIGHT;
        _rowHeader             = new TextBox[_rows];
        _panelRowHeader.Width  = CELL_WIDTH;
        for (var row = 0; row < _rows; row++)
        {
            textBox          = CreateTextBox(Color.SkyBlue, row.ToString());
            _rowHeader[row]  = textBox;
            textBox.Location = new(0, row * CELL_HEIGHT);
            _panelRowHeader.Controls.Add(textBox);
        }

        _panelAll.Controls.Add(_panelRowHeader);
        _panelRowHeader.Location = new(0, CELL_HEIGHT);
        Text                     = "";
        CreateCells(_rows, _cols);
        _panelBoard.Location = new(CELL_WIDTH, CELL_HEIGHT);
        _panelAll.Width      = _panelBoard.Width + CELL_WIDTH;
        _panelAll.Height     = _panelBoard.Height + CELL_HEIGHT;
        ClientSize           = new(_panelAll.Width, _panelAll.Height);
        StartPosition        = FormStartPosition.Manual;
        SetDesktopLocation(800, 50);
    }

    private void SetTextToCellDelegate(int row, int col, string text, string color)
    {
        _board[row, col].Text      = text;
        _board[row, col].ForeColor = GetFormsColor(color);
    }

    /// <summary>
    ///     Text in Zeile und Spalte schreiben. In Context des Windows-Threads umschalten.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="text"></param>
    public void SetText(int row, int col, string text)
    {
        _board[row, col].Invoke(new SetTextDelegate(SetTextToCellDelegate), row, col, text, "Black");
    }

    /// <summary>
    ///     Text in Zeile und Spalte in der entsprechenden Farbe ausgeben
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="text"></param>
    /// <param name="color"></param>
    public void SetText(int row, int col, string text, string color)
    {
        _board[row, col].Invoke(new SetTextDelegate(SetTextToCellDelegate), row, col, text, color);
    }

    /// <summary>
    ///     Auslesen der Zelle an der gegebenen Position
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public string GetText(int row, int col)
    {
        return _board[row, col].Text;
    }

    /// <summary>
    ///     Die Felder für das Spielfeld werden erzeugt.
    /// </summary>
    /// <param name="rows"></param>
    /// <param name="cols"></param>
    private void CreateCells(int rows, int cols)
    {
        for (var row = 0; row < rows; row++)
        for (var col = 0; col < cols; col++)
        {
            CreateCell(row, col);
        }
    }

    /// <summary>
    ///     Ein Feld wird erzeugt. Die Position ergibt sich aus Zeile und Spalte.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    private void CreateCell(int row, int col)
    {
        var textBox = CreateTextBox(Color.White, "");
        _board[row, col] = textBox;
        _board[row, col].Click += (sender, args) =>
        {
            if (sender is TextBox)
            {
                var t = sender as TextBox;
                int x = t!.Location.X / CELL_HEIGHT;
                int y = t!.Location.Y / CELL_WIDTH;
                Board.OnCellClicked(y, x);
            }
        };

        textBox.Location = new(col * CELL_WIDTH, row * CELL_HEIGHT);
        _panelBoard.Controls.Add(textBox);
    }

    /// <summary>
    ///     Eine Textbox wird erzeugt
    /// </summary>
    /// <param name="backGround">Hintergrundfarbe</param>
    /// <param name="text">Anzuzeigender Text</param>
    /// <returns></returns>
    private static TextBox CreateTextBox(Color backGround, string text)
    {
        var textBox = new TextBox();
        textBox.Font        = new("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox.Size        = new(CELL_WIDTH, CELL_HEIGHT);
        textBox.TabStop     = false;
        textBox.TextAlign   = HorizontalAlignment.Center;
        textBox.BackColor   = backGround;
        textBox.ReadOnly    = true;
        textBox.Text        = text;
        textBox.BorderStyle = BorderStyle.Fixed3D;
        return textBox;
    }

    /// <summary>
    ///     Umwandlung des Farbtextes in die entsprechende Forms-Farbe
    /// </summary>
    /// <param name="textColor">Text für die vorgegebenen Farben</param>
    /// <returns></returns>
    private static Color GetFormsColor(string textColor)
    {
        if (string.IsNullOrEmpty(textColor))
        {
            return Color.Black;
        }

        if (Enum.TryParse(textColor, out KnownColor color))
        {
            return Color.FromName(textColor);
        }

        throw new ArgumentException($"you have specified a wrong color: {textColor}");
    }

    /// <summary>
    ///     Delegate als Parameter zum Verändern der Texte im WinForm
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="text"></param>
    /// <param name="color"></param>
    private delegate void SetTextDelegate(int row, int col, string text, string color);
}

# endregion