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
        string board = "AXXXXXAXXXXXAXXXXXXXXXXXBBbBXXXXXXXXXXXXXX";
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

