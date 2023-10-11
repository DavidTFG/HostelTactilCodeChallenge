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
        string board = "_QQQQQ_WWWWW_EEEEE_RRRRR_TTTTT_YYYYYXUUUUU";
        try
        {
            if (_connectFourRepository.CheckSizeBoard(board))
            {
                if (_connectFourRepository.CheckBalancedPieces(board))
                {
                    if (_connectFourRepository.CheckAStarted(board))
                    {
                        if (_connectFourRepository.CheckPhysicallyPositions(board))
                        {
                            return Ok("yes");
                        }
                        else
                        {
                            return BadRequest("There are pieces on the board that cannot be physically placed there.");
                        }
                    }
                    else
                    {
                        return BadRequest("Player A didn't started.");
                    }
                }
                else
                {
                    return BadRequest("The board is not balanced: The Team A and Team B ahave a different number of pieces.");

                }

            }
            else
            {
                return BadRequest("The number of pieces of the board is different than expected.");

            }

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

}

