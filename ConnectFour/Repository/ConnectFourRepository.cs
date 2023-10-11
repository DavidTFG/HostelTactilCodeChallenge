using System.Collections.Generic;

namespace ConnectFour.Repository;

public class ConnectFourRepository
{
    private const int ROWS = 6;
    private const int COLUMNS = 7;

    //Checks if the given board has balanced pieces, meaning the difference in the counts of 'A' and 'B' pieces is not greather than 1.
    public bool CheckBalancedPieces(string board)
    {
        int countA = board.Count(piece => piece == 'A');
        int countB = board.Count(piece => piece == 'B');
        if (Math.Abs(countA - countB) > 1)
        {
            return false;
        }
        return true;
    }

    //Check if the pieces from the board are physically positioned correctly.
    public bool CheckPhysicallyPositions(string board)
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

    public bool CheckWinner(string board)
    {
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

    public bool CheckSizeBoard(string board)
    {
        if (board.Length != COLUMNS * ROWS)
        {
            return false;
        }
        return true;
    }

}