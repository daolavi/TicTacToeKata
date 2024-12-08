namespace TicTacToeKata.Logic;

public class TicTacToe
{
    public char?[,] Board { get; private set; }
    public char CurrentPlayer { get; private set; }
    public char? Winner { get; private set; }
    private bool _isOver;
    
    public TicTacToe()
    {
        Board = new char?[3, 3];
        CurrentPlayer = 'X';
    }

    public void MakeMove(int row, int column)
    {
        if (_isOver)
        {
            throw new Exception($"The game is over");
        }
        
        if (Board[row, column] is not null)
        {
            throw new Exception($"Cell [{row},{column}] is already occupied");
        }
        
        Board[row, column] = CurrentPlayer;

        var isWinnerFound = CheckWinner();
        if (!isWinnerFound && !IsBoardCompleted())
        {
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';   
        }
        else
        {
            _isOver = true;
            if (isWinnerFound)
            {
                Winner = CurrentPlayer;
            }
        }
    }

    private bool CheckWinner()
    {
        //check rows
        //check columns
        //check diagonals
        if (CheckRows() || CheckColumns() || CheckDiagonals())
        {
            return true;
        }

        return false;
    }

    private bool CheckRows()
    {
        for (var i = 0; i < 3; i++)
        {
            if (Board[i, 0] == CurrentPlayer
                && Board[i, 1] == CurrentPlayer
                && Board[i, 2] == CurrentPlayer)
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckColumns()
    {
        for (var i = 0; i < 3; i++)
        {
            if (Board[0, i] == CurrentPlayer
                && Board[1, i] == CurrentPlayer
                && Board[2, i] == CurrentPlayer)
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckDiagonals()
    {
        if (Board[0, 0] == CurrentPlayer
            && Board[1, 1] == CurrentPlayer
            && Board[2, 2] == CurrentPlayer)
        {
            return true;
        }

        if (Board[2, 0] == CurrentPlayer
            && Board[1, 1] == CurrentPlayer
            && Board[0, 2] == CurrentPlayer)
        {
            return true;
        }

        return false;
    }

    private bool IsBoardCompleted()
    {
        foreach (var cell in Board)
        {
            if (cell is null)
            {
                return false;
            }
        }

        return true;
    }
}