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
        string board = "AXXXXXAXXXXXAXXXXXAXXXXXBBBXXXXXXXXXXXXXXX";
        try
        {
            string preconditionFailed = _connectFourRepository.CheckPreconditions(board);
            if (preconditionFailed.Length == 0)
            {
                return Ok("Calcular Ganador");
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

