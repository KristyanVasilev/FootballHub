using FootballHub.Application.Interfaces;
using FootballHub.Application.Models.PlayerApiModels;
using FootballHub.Application.Repositories;
using FootballHub.Application.Services;
using FootballHub.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Formats.Asn1.AsnWriter;

public class PlayerUpdateService : BackgroundServiceBase
{
    private readonly IServiceProvider _serviceProvider;
    //private readonly ITeamService _teamService;



    public PlayerUpdateService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
       // _teamService = teamService;
    }

    //public PlayerUpdateService()
    //{
        
    //}

    protected override TimeSpan Interval => TimeSpan.FromDays(3); // Set the interval to 3 days

    protected override async Task DoWork(CancellationToken cancellationToken)
    {
       
        try
        {
            using var scope = _serviceProvider.CreateScope();
            // Retrieve all players from the team service
            var _teamService = scope.ServiceProvider.GetRequiredService<ITeamService>();

            var allPlayers = await _teamService.GetPlayersInfo();

            // Process and update the database with the player information
            await UpdateDatabase(allPlayers.Response);

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating player information.");
        }
    }

    private async Task UpdateDatabase(PlayerResponseApiModel[] playerResponses)
    {
        using var scope = _serviceProvider.CreateScope();

        var playerRepository = scope.ServiceProvider.GetRequiredService<IDeletableEntityRepository<Player>>();

        foreach (var playerResponse in playerResponses)
        {
            // Map PlayerResponseApiModel to your Player entity
            var playerEntity = new Player
            {
                Id = playerResponse.Player.Id,
                Name = playerResponse.Player.Name,
                FirstName = playerResponse.Player.Firstname,
                LastName = playerResponse.Player.Lastname,
                Age = playerResponse.Player.Age,
                Nationality = playerResponse.Player.Nationality,
                Photo = playerResponse.Player.Photo,
                Injured = playerResponse.Player.Injured,
                // Map other properties

                Birth = new Birth
                {
                    Date = playerResponse.Player.Birth.Date,
                }
            };

            // Check if the player already exists in the database
            var existingPlayer = playerRepository
                .All()
                .FirstOrDefault(p => p.Id == playerEntity.Id);

            if (existingPlayer == null)
            {
                //await playerRepository.AddAsync(playerEntity);
            }
            else
            {
                existingPlayer.Name = playerEntity.Name;
                existingPlayer.FirstName = playerEntity.FirstName;

                playerRepository.Update(existingPlayer);
            }
        }

        await playerRepository.SaveChangesAsync();

    }
}

