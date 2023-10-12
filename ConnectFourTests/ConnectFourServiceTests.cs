using ConnectFour.Services;
using ConnectFour.Repositories;
using Moq;
namespace TestConnectFour;

public class ConnectFourServiceTests
{
    private readonly ConnectFourService _sut;
    private readonly Mock<IConnectFourRepository> _connectFourRepoMock = new Mock<IConnectFourRepository>();


    public ConnectFourServiceTests()
    {
        _sut = new ConnectFourService(_connectFourRepoMock.Object);
    }

    [Theory]
    [InlineData("AAAAAAXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "A")]
    [InlineData("AXXXXXAXXXXXAXXXXXAXXXXXBBBXXXXXXXXXXXXXXX", "A")]
    [InlineData("AAXXXXBXXXXXABXXXXAABXXXBBABXXXXXXXXXXXXXX", "B")]
    [InlineData("AXXXXXXXXXXXXXXXXXBXXXXXABXXXXABBAXXABABXX", "B")]
    [InlineData("AXXXXXAXXXXXBXXXXXAXXXXXABXXXXABBBXXABABXX", "X")]
    [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "X")]
    public void CheckWinner_ShouldReturnWinner(string board, string expected)
    {
        //Arrange
        _connectFourRepoMock.Setup(repo => repo.CheckWinner(board)).Returns(expected);
        //Act
        string result = _sut.CheckWinner(board);
        //Assert
        Assert.Equal(expected, result);
    }
}