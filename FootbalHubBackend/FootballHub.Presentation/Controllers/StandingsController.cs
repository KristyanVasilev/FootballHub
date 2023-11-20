namespace FootballHub.Presentation.Controllers
{
    using FootballHub.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class StandingsController : Controller
    {
        private readonly IStandingsService _standingService;

        public StandingsController(IStandingsService standingService)
        {
            _standingService = standingService;
        }

        [HttpGet("GetStandingsInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetStandingsInfo()
        {
            try
            {
                var coach = await _standingService.GetStandingsInfo();
                return Ok(coach);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
