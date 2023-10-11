using Microsoft.AspNetCore.Mvc;
using ConnectFour.Repository;
namespace ConnectFour.Controllers;

[ApiController]
[Route("ht/api/connect-four")]
public class ConnectFourController : ControllerBase
{

    private readonly ConnectFourRepository _connectFourRepository;

    public ConnectFourController(ConnectFourRepository connectFourRepository)
    {
        _connectFourRepository = connectFourRepository;
    }

    [HttpGet]
    public IActionResult GetWinner()
    {
        string board = "XXXXXXBXXXXXXXXXAXXXXXXXXXXAXXXXXXXXXXXXXX";
        try
        {
            if (_connectFourRepository.CheckPhysicallyPositions(board))
            {
                if (_connectFourRepository.CheckBalancedPieces(board))
                {
                    return Ok("yes");
                }
                else
                {
                    return BadRequest("The board is not balanced: The Team A and Team B ahave a different number of pieces.");

                }
            }
            else
            {
                return BadRequest("There are positions on the board that are not physically possible.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

}

