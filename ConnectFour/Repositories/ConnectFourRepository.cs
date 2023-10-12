using ConnectFour.Models;
namespace ConnectFour.Repositories;

public class ConnectFourRepository : IConnectFourRepository
{
    //Launches the checks of all preconditions, returning a message depending on the precondition that has failed
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

    //Checks the board for a winning chain in horizontal, vertical, or diagonal directions. Returning the winning char.
    public string CheckWinner(string board)
    {
        char piece1, piece2, piece3, piece4;
        int position;


        //Checks vertical chains
        for (int columna = 0; columna < Board.COLUMNS; columna++)
        {
            for (int fila = 0; fila < Board.ROWS - 3; fila++)
            {
                position = columna * Board.ROWS + fila;
                piece1 = board[position];
                piece2 = board[position + 1];
                piece3 = board[position + 2];
                piece4 = board[position + 3];
                if (CheckChain(piece1, piece2, piece3, piece4))
                {
                    return piece1.ToString();
                }
            }
        }

        //Checks horizontal chains
        for (int fila = 0; fila < Board.ROWS; fila++)
        {
            for (int columna = 0; columna < Board.COLUMNS - 3; columna++)
            {
                position = columna * Board.ROWS + fila;
                piece1 = board[position];
                piece2 = board[position + Board.ROWS];
                piece3 = board[position + Board.ROWS * 2];
                piece4 = board[position + Board.ROWS * 3];
                if (CheckChain(piece1, piece2, piece3, piece4))
                {
                    return piece1.ToString();
                }

            }
        }

        //Checks ascending diagonal chains
        for (int columna = 0; columna < Board.COLUMNS - 3; columna++)
        {
            for (int fila = 0; fila < Board.ROWS - 3; fila++)
            {
                position = columna * Board.ROWS + fila;
                piece1 = board[position];
                piece2 = board[position + (Board.ROWS + 1)];
                piece3 = board[position + (Board.ROWS + 1) * 2];
                piece4 = board[position + (Board.ROWS + 1) * 3];
                if (CheckChain(piece1, piece2, piece3, piece4))
                {
                    return piece1.ToString();
                }
            }
        }

        //Checks descending diagonal chains
        for (int columna = 0; columna < Board.COLUMNS - 3; columna++)
        {
            for (int fila = 3; fila < Board.ROWS; fila++)
            {
                position = columna * Board.ROWS + fila;
                piece1 = board[position];
                piece2 = board[position + (Board.ROWS - 1)];
                piece3 = board[position + (Board.ROWS - 1) * 2];
                piece4 = board[position + (Board.ROWS - 1) * 3];
                if (CheckChain(piece1, piece2, piece3, piece4))
                {
                    return piece1.ToString();
                }
            }
        }

        return "X";
    }

    //Checks if the provided board has the correct size, which should be equal to the product of COLUMNS and ROWS.
    private bool CheckSizeBoard(string board)
    {
        if (board.Length != Board.COLUMNS * Board.ROWS)
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
        if ((countA - countB) >= 0 && (countA - countB) <= 1 && ((countA + countB + countX) == (Board.ROWS * Board.COLUMNS)))
        {
            return true;
        }
        return false;
    }

    //Checks if in the provided board is there at least one 'A' piece in the bottom of a column
    private bool CheckAStarted(string board)
    {
        char[] bottomPieces = new char[Board.COLUMNS];
        int index = 0;
        for (int position = 0; position < board.Length; position += Board.ROWS)
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
    //Checks if the pieces from the board are physically positioned correctly.
    private bool CheckPhysicallyPositions(string board)
    {
        int totalLength = board.Length;
        int columnsLength = totalLength / Board.COLUMNS;
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

    //Checks if the pieces in a column are physically positioned correctly.
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

    //Checks if four pieces in a row have the same non-empty value.
    private static bool CheckChain(char piece1, char piece2, char piece3, char piece4)
    {
        if ((piece1 == piece2)
            && (piece1 == piece3)
            && (piece1 == piece4)
            && piece1 != 'X')
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}