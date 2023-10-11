namespace ConnectFour.Repository;
public interface IConnectFourRepository
{
    //Checks whether the pieces on the board are physically positioned correct
    bool CheckPhysicallyPositions(string board);

    //Checks whether the number of pieces for each player on the board are either the same or Team A exactly one more piece than Team B
    bool CheckBalancedPieces(string board);

    //Checks for a winner based on the current state of the board
    bool CheckWinner(string board);
}