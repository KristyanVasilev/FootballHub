namespace FootballHub.Presentation.Controllers
{
    using FootballHub.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService _coachService;
        private readonly IFixtureService _fService;

        public CoachController(ICoachService coachService, IFixtureService fService)
        {
            _coachService = coachService;
            _fService = fService;
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

        [HttpGet("GetfInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetfInfo()
        {
            try
            {
                var coach = await _fService.GetAllFixturesInfo();
                return Ok(coach);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("GetftInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetftInfo()
        {
            try
            {
                var coach = await _fService.GetFixturesInfo();
                //var coach = "[\r\n  {\r\n    \"fixture\": {\r\n      \"id\": \"999112\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-01-25T00:00:00+00:00\",\r\n      \"timestamp\": 1674604800,\r\n      \"periods\": {\r\n        \"first\": \"1674604800\",\r\n        \"second\": \"1674608400\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-3.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"4\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n  {\r\n    \"fixture\": {\r\n      \"id\": \"1036410\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-06-24T07:30:00+00:00\",\r\n      \"timestamp\": 1687591800,\r\n      \"periods\": {\r\n        \"first\": \"1687591800\",\r\n        \"second\": \"1687595400\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"1883\",\r\n        \"name\": \"Stadion Lokomotiv\",\r\n        \"city\": \"Sofia\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1416\",\r\n        \"name\": \"Lokomotiv Sofia\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/1416.png\",\r\n        \"winner\": \"false\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"true\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"1\",\r\n      \"away\": \"2\"\r\n    }\r\n  },\r\n  {\r\n    \"fixture\": {\r\n      \"id\": \"1036546\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-06-22T00:00:00+00:00\",\r\n      \"timestamp\": 1687392000,\r\n      \"periods\": {\r\n        \"first\": \"1687392000\",\r\n        \"second\": \"1687395600\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": null,\r\n        \"name\": \"Terenite na Evima Futbol\",\r\n        \"city\": \"Bansko\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"566\",\r\n        \"name\": \"Ludogorets\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/566.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-3.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"1\",\r\n      \"away\": \"0\"\r\n    }\r\n  },\r\n  {\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n{\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n{\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n{\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n{\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n{\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n{\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n{\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  },\r\n{\r\n    \"fixture\": {\r\n      \"id\": \"1051787\",\r\n      \"referee\": null,\r\n      \"timezone\": \"UTC\",\r\n      \"date\": \"2023-07-08T00:00:00+00:00\",\r\n      \"timestamp\": 1688774400,\r\n      \"periods\": {\r\n        \"first\": \"1688774400\",\r\n        \"second\": \"1688778000\"\r\n      },\r\n      \"venue\": {\r\n        \"id\": \"303\",\r\n        \"name\": \"Stadion Hristo Botev\",\r\n        \"city\": \"Blagoevgrad\"\r\n      },\r\n      \"status\": {\r\n        \"long\": \"Match Finished\",\r\n        \"short\": \"FT\",\r\n        \"elapsed\": \"90\"\r\n      }\r\n    },\r\n    \"teams\": {\r\n      \"home\": {\r\n        \"id\": \"1428\",\r\n        \"name\": \"Pirin Blagoevgrad\",\r\n        \"logo\": \"https://media-1.api-sports.io/football/teams/1428.png\",\r\n        \"winner\": \"true\"\r\n      },\r\n      \"away\": {\r\n        \"id\": \"8543\",\r\n        \"name\": \"Marek\",\r\n        \"logo\": \"https://media-2.api-sports.io/football/teams/8543.png\",\r\n        \"winner\": \"false\"\r\n      }\r\n    },\r\n    \"goals\": {\r\n      \"home\": \"3\",\r\n      \"away\": \"1\"\r\n    }\r\n  }\r\n]";
                return Ok(coach);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("GetNExtInfo")]
        [ResponseCache(Duration = 259200)]
        public async Task<IActionResult> GetNExtInfo()
        {
            try
            {
                var coach = await _fService.GetCurrentGameInfo();
                return Ok(coach);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Getgame")]
        public async Task<IActionResult> GetNExtInfo(int id)
        {
            try
            {
                //var coach = await _fService.GetCurrentGameInfo();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
