using Microsoft.AspNetCore.Mvc;
using ConnectFour.Repository;
namespace ConnectFour.Controllers;

//The Class ConnectFourController handle the HTTP POST request, validate the game board, and provide a reponse based on the game logic and conditions.
[ApiController]
[Route("ht/api/connect-four")]
public class ConnectFourController : ControllerBase
{

    private readonly ConnectFourRepository _connectFourRepository;

    public ConnectFourController(ConnectFourRepository connectFourRepository)
    {
        _connectFourRepository = connectFourRepository;
    }


    //The method Post calls the repository which verifies the preconditions and determines the game winner from a board.
    [HttpPost]
    public IActionResult Post([FromBody] string board)
    {
        try
        {
            board = board.ToUpper();
            string preconditionFailed = _connectFourRepository.CheckPreconditions(board);
            if (preconditionFailed.Length == 0)
            {
                return Ok(_connectFourRepository.CheckWinner(board));
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

