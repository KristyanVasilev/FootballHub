﻿namespace FootballHub.Presentation.Controllers
{
    using FootballHub.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class StandingController : Controller
    {
        private readonly IStandingService _standingService;

        public StandingController(IStandingService standingService)
        {
            _standingService = standingService;
        }

        [HttpGet("GetStandingInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetStandingInfo()
        {
            try
            {
                var coach = await _standingService.GetStandingInfo();
                return Ok(coach);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
