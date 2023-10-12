namespace ConnectFour.Services;

public interface IConnectFourService
{
    string CheckPreconditions(string board);
    string CheckWinner(string board);
}
