using Microsoft.AspNetCore.Mvc;
using ConnectFour.Services;
namespace ConnectFour.Controllers;

//The Class ConnectFourController handle the HTTP POST request, validate the game board, and provide a reponse based on the game logic and conditions.
[ApiController]
[Route("ht/api/connect-four")]
public class ConnectFourController : ControllerBase
{

    private readonly IConnectFourService _connectFourService;

    public ConnectFourController(IConnectFourService connectFourService)
    {
        _connectFourService = connectFourService;
    }


    //The method Post calls the service that calls the repository to check de preconditions, if no preconditions then call the service to check the winner.
    [HttpPost]
    public IActionResult Post([FromBody] string board)
    {
        try
        {
            board = board.ToUpper();
            string preconditionFailed = _connectFourService.CheckPreconditions(board);
            if (preconditionFailed.Length == 0)
            {
                return Ok(_connectFourService.CheckWinner(board));
            }
            else
            {
                return BadRequest(preconditionFailed);
            }

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

}

