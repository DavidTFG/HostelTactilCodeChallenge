using ConnectFour.Repositories;
using ConnectFour.Services;
using Moq;
using Xunit;
namespace TestConnectFour;

public class ConnectFourServiceTests
{

    private readonly ConnectFourService _connectFourService;
    private readonly Mock<IConnectFourRepository> _connectFourRepositoryMock;

    public ConnectFourServiceTests()
    {
        _connectFourRepositoryMock = new Mock<IConnectFourRepository>();
        _connectFourService = new ConnectFourService(_connectFourRepositoryMock.Object);
    }

    [Theory]
    //Test case for A vertical win
    [InlineData("AAAAAAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "A")]
    //Test case for A horizontal win
    [InlineData("AXXXXXAXXXXXAXXXXXAXXXXXBBBXXXXXXXXXXXXXXX", "A")]
    //Test case for B diagonal ascending win
    [InlineData("AAXXXXBXXXXXABXXXXAABXXXBBABXXXXXXXXXXXXXX", "B")]
    //Test case for B diagonal descending win
    [InlineData("AXXXXXXXXXXXXXXXXXBXXXXXABXXXXABBAXXABABXX", "B")]
    //Test case for X win, neither a nor b
    [InlineData("AXXXXXAXXXXXBXXXXXAXXXXXABXXXXABBBXXABABXX", "X")]
    //Test case for X win, empty board
    [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "X")]
    public void CheckWinner_ShouldReturnWinner(string board, string expected)
    {
        //Arrange
        _connectFourRepositoryMock.Setup(repository => repository.CheckWinner(board)).Returns(expected);

        //Act
        string result = _connectFourService.CheckWinner(board);

        //Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    //Test case for less board pieces
    [InlineData("XXXXXXAAAAAABBBBBB", "The number of pieces of the board is different than expected.")]
    //Test case for unbalanced board
    [InlineData("ABAAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "The board is not balanced: The Team A and Team B have different number of pieces.")]
    //Test case for board not starting A
    [InlineData("BAXXXXBAXXXXBAXXXXBXXXXXBAXXXXBAXXXXBAXXXX", "Player A didn't started.")]
    //Test case for pieces not physically placed correctly
    [InlineData("XXBXXXXXXXXXXXXXABXXXXXXXXXXXXXXXAXXXXXXXX", "There are pieces on the board that cannot be physically placed there.")]
    //Test case for board with all preconditions passed
    [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "")]
    public void CheckPreconditions_ShouldReturnPreconditionFailedMessage(string board, string expected)
    {
        //Arrange
        _connectFourRepositoryMock.Setup(repository => repository.CheckPreconditions(board)).Returns(expected);

        //Act
        string result = _connectFourService.CheckPreconditions(board);

        //Assert
        Assert.Equal(expected, result);
    }
}