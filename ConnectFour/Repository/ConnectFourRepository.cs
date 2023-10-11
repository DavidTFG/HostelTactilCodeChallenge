using System.Collections.Generic;

namespace ConnectFour.Repository;

public class ConnectFourRepository : IConnectFourRepository
{
    private const int ROWS = 6;
    private const int COLUMNS = 7;
    public bool CheckBalancedPieces(string board)
    {
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

}