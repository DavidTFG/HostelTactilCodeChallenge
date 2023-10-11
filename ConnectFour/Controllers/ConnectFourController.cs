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
        string board = "AAAXXXBBXXXXXXXXXXXXXXXXXXXXXXXXXXXXABABXB";
        try
        {
            if (_connectFourRepository.CheckPhysicallyPositions(board))
            {
                return Ok("yes");
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

