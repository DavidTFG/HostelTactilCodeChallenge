using System.Collections.Generic;
using System.Text;

namespace ConnectFour.Repository;

public class ConnectFourRepository
{
    private const int ROWS = 6;
    private const int COLUMNS = 7;

    //Launches the checks of all the preconditions, returning a message depending on the precondition that has failed
    public string CheckPreconditions(string board)
    {
        if (!CheckSizeBoard(board))
        {
            return "The number of pieces of the board is different than expected.";
        }
        if (!CheckBalancedPieces(board))
        {
            return "The board is not balanced: The Team A and Team B have different number of pieces.";
        }
        if (!CheckAStarted(board))
        {
            return "Player A didn't started.";
        }
        if (!CheckPhysicallyPositions(board))
        {
            return "There are pieces on the board that cannot be physically placed there.";
        }
        return "";
    }

    //Check if the provided board has the correct size, which should be equal to the product of COLUMNS and ROWS.
    private bool CheckSizeBoard(string board)
    {
        if (board.Length != COLUMNS * ROWS)
        {
            return false;
        }
        return true;
    }

    //Checks if the given board has balanced pieces, meaning the difference in the counts of 'A' and 'B' pieces is not greather than 1.
    private bool CheckBalancedPieces(string board)
    {
        int countA = board.Count(piece => piece == 'A');
        int countB = board.Count(piece => piece == 'B');
        int countX = board.Count(piece => piece == 'X');
        if (Math.Abs(countA - countB) <= 1 && ((countA + countB + countX) == (ROWS * COLUMNS)))
        {
            return true;
        }
        return false;
    }

    //Check if in the provided board is there at least one 'A' piece in the bottom of a column
    private bool CheckAStarted(string board)
    {
        char[] bottomPieces = new char[COLUMNS];
        int index = 0;
        for (int position = 0; position < board.Length; position += ROWS)
        {
            bottomPieces[index] = board[position];
            index++;
        }
        if (bottomPieces.Count(piece => piece == 'A') >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Check if the pieces from the board are physically positioned correctly.
    private bool CheckPhysicallyPositions(string board)
    {
        int totalLength = board.Length;
        int columnsLength = totalLength / COLUMNS;
        List<string> columns = new List<string>();

        for (int i = 0; i < totalLength; i += columnsLength)
        {
            if (i + columnsLength <= totalLength)
                columns.Add(board.Substring(i, columnsLength));
        }
        foreach (string column in columns)
        {
            if (!CheckPhysicallyColumnPositions(column))
            {
                return false;
            }
        }
        return true;
    }

    //Check if the pieces in a column are physically positioned correctly.
    private bool CheckPhysicallyColumnPositions(string column)
    {
        char lastPiece = 'A';
        for (int i = 0; i < column.Length; i++)
        {
            if (lastPiece == 'X' && column[i] != 'X')
            {
                return false;
            }
            lastPiece = column[i];
        }
        return true;
    }

    public bool CheckWinner(string board)
    {
        return true;
    }






}