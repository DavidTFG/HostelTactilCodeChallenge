using ConnectFour.Repositories;

namespace ConnectFour.Services;

public class ConnectFourService : IConnectFourService
{
    private readonly IConnectFourRepository _connectFourRepository;
    public ConnectFourService(IConnectFourRepository connectFourRepository)
    {
        _connectFourRepository = connectFourRepository;
    }

    //Calls service function to check preconditions returning the precondition string
    public string CheckPreconditions(string board)
    {
        return _connectFourRepository.CheckPreconditions(board);
    }

    //Calls service function that returns the winner
    public string CheckWinner(string board)
    {
        return _connectFourRepository.CheckWinner(board);
    }
}