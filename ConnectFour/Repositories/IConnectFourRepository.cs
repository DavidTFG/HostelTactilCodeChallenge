using ConnectFour.Models;

namespace ConnectFour.Repositories;

public interface IConnectFourRepository
{
    string CheckPreconditions(string board);
    string CheckWinner(string board);
}