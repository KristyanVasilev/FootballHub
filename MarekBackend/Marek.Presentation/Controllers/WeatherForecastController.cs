using Marek.Application.Interfaces;
using Marek.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marek.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ICoachService _transfersService;

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGetApiInfoService _testService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICoachService coachService, IGetApiInfoService testService)
        {
            _logger = logger;
            _transfersService = coachService
                                ?? throw new ArgumentNullException(nameof(CoachService));
            _testService = testService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("transfersLev")]
        public async Task<IActionResult> GetTransfersLev()
        {
            try
            {
                var transfers = await _transfersService.GetCoachInfo();
                return Ok(transfers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("team")]
        public async Task<IActionResult> GetTeam()
        {
            try
            {
                var team = await _testService.GetApiResponse<string>("https://api-football-v1.p.rapidapi.com/v3/players?team=8543&season=2022");
                return Ok(team);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}