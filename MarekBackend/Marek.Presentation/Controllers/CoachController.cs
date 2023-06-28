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
                var coach = await _coachService.GetCoachInfo();
                return Ok(coach);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
