namespace FootballHub.Presentation.Controllers
{
    using FootballHub.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class TeamController : Controller
    {

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }


        [HttpGet("GetPlayersInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetTeamInfo()
        {
            try
            {
                var coach = await _teamService.GetPlayersInfo();
                return Ok(coach);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
