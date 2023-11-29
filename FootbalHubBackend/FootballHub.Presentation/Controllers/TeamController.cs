namespace FootballHub.Presentation.Controllers
{
    using FootballHub.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class TeamController : Controller
    {

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }


        [HttpGet("GetPlayersInfo2")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetTeamInfo()
        {
            try
            {
                var players = await _teamService.GetPlayersInfo();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetPlayers")]
        public IActionResult GetAllPlayers()
        {
            try
            {
                var players = _teamService.GetAllPlayers();
                return Ok(players);
            }
            catch (InvalidCastException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllPlayers")]
        public IActionResult GetPlayers()
        {
            try
            {
                var players = _teamService.GetAllPlayers();
                return Ok(players);
            }
            catch (InvalidCastException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
