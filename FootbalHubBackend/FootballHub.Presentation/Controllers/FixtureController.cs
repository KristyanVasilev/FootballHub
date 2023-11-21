using FootballHub.Application.Interfaces;
using FootballHub.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FootballHub.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FixtureController : Controller
    {
        private readonly IFixtureService _fixturesService;

        public FixtureController(IFixtureService fixtureService)
        {
            _fixturesService = fixtureService;
        }

        [HttpGet("GetNextGameInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetStandingsInfo()
        {
            try
            {
                var nextGame = await _fixturesService.GetNextGameInfo();
                return Ok(nextGame);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetLatestFixturesInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetLatestFixturesInfo()
        {
            try
            {
                var latestFixtures = await _fixturesService.GetLatetsFixturesInfo();
                return Ok(latestFixtures);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("GetNextFixturesInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetNextFixturesInfo()
        {
            try
            {
                var nextFixtures = await _fixturesService.GetNextFixturesInfo();
                return Ok(nextFixtures);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
