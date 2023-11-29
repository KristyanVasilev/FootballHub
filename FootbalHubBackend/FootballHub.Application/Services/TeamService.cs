using FootballHub.Application.Config;
using FootballHub.Application.Interfaces;
using FootballHub.Application.Models.PlayerApiModels;
namespace FootballHub.Application.Services
{
    using FootballHub.Application.Models.DTOs;
    using FootballHub.Application.Repositories;
    using FootballHub.Domain;
    using Microsoft.Extensions.Options;
    using System.Runtime.CompilerServices;

    public class TeamService : ITeamService
    {
        private readonly IGetApiInfoService _getApiInfoService;
        private readonly IDeletableEntityRepository<Player> _repository;
        private readonly ApiConfig _apiConfig;

        public TeamService
            (IGetApiInfoService getApiInfoService,
            IDeletableEntityRepository<Player> repository,
            IOptions<ApiConfig> apiConfigOptions)
        {
            _getApiInfoService = getApiInfoService;
            _repository = repository;
            _apiConfig = apiConfigOptions.Value;
        }

        public async Task<PlayerRotoObject> GetPlayersInfo()
        {
            try
            {
                var players = await _getApiInfoService.GetApiResponse<PlayerRotoObject>(_apiConfig.TeamApiUrl);
                
                return players;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        //public async Task<string> Test()
        //{

        //    try
        //    {
        //        // Retrieve all players from the team service
        //        var allPlayers = await GetPlayersInfo();

        //        // Process and update the database with the player information
        //        await UpdateDatabase(allPlayers.Response);

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error updating player information.");
        //    }

        //    return "test";
        //}

        //private async Task UpdateDatabase(PlayerResponseApiModel[] playerResponses)
        //{
        //   //using var scope = _serviceProvider.CreateScope();

        //    //var playerRepository = scope.ServiceProvider.GetRequiredService<IDeletableEntityRepository<Player>>();

        //    foreach (var playerResponse in playerResponses)
        //    {
        //        // Map PlayerResponseApiModel to your Player entity
        //        var playerEntity = new Player
        //        {
        //           // Id = playerResponse.Player.Id,
        //            Name = playerResponse.Player.Name,
        //            FirstName = playerResponse.Player.Firstname,
        //            LastName = playerResponse.Player.Lastname,
        //            Age = playerResponse.Player.Age,
        //            Nationality = playerResponse.Player.Nationality,
        //            Photo = playerResponse.Player.Photo,
        //            Injured = playerResponse.Player.Injured,
        //            Birth = new Birth
        //            {
        //                Date = playerResponse.Player.Birth.Date,
        //            }
        //        };

        //        // Check if the player already exists in the database
        //        var existingPlayer = _repository
        //            .All()
        //            .FirstOrDefault(p => p.Id == playerEntity.Id);

        //        if (existingPlayer == null)
        //        {
        //            await _repository.AddAsync(playerEntity);
        //            await _repository.SaveChangesAsync();

        //        }
        //        else
        //        {
        //            existingPlayer.Name = playerEntity.Name;
        //            existingPlayer.FirstName = playerEntity.FirstName;

        //            _repository.Update(existingPlayer);
        //            continue;
        //        }
        //    }

        //    await _repository.SaveChangesAsync();

        //}

        public IEnumerable<PlayerDto> GetAllPlayers()
        {
            var result = this._repository.AllAsNoTracking()
                            .Select(player => new PlayerDto
                            {
                                Id = player.Id,
                                Name = player.Name,
                                Photo = player.Photo,
                            }).OrderBy(p => p.Name)
                            .ToList(); // Execute the query immediately

            Console.WriteLine(result);
            if (!result.Any())
            {
                throw new InvalidCastException("No players found!"); // Custom exception for no players found
            }

            return result;
        }
    }
}
