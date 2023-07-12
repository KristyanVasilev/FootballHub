namespace Marek.Presentation.Controllers
{
    using Marek.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }

        [HttpGet("GetCoachInfo")]
        public async Task<IActionResult> GetCoachInfo()
        {
            try
            {
                //var coach = await _coachService.GetCoachInfo();
                var coach = "{\r\n  \"firstName\": \"Tancho\",\r\n  \"lastName\": \"Donchev Kalpakov\",\r\n  \"age\": null,\r\n  \"photoUrl\": \"https://media-3.api-sports.io/football/coachs/19029.png\",\r\n  \"nationality\": \"Bulgaria\",\r\n  \"career\": [\r\n    {\r\n      \"team\": {\r\n        \"id\": 8543,\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\"\r\n      },\r\n      \"start\": \"2022-07-01\",\r\n      \"end\": null\r\n    },\r\n    {\r\n      \"team\": {\r\n        \"id\": 4659,\r\n        \"name\": \"Hebar 1918\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/4659.png\"\r\n      },\r\n      \"start\": \"2018-01-01\",\r\n      \"end\": \"2018-09-01\"\r\n    },\r\n    {\r\n      \"team\": {\r\n        \"id\": 1411,\r\n        \"name\": \"Oborishte\",\r\n        \"logo\": \"https://media-3.api-sports.io/football/teams/1411.png\"\r\n      },\r\n      \"start\": \"2016-07-01\",\r\n      \"end\": \"2016-10-01\"\r\n    }\r\n  ]\r\n}";
                return Ok(coach);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
