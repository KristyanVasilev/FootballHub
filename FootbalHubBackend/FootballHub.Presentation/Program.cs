using FootballHub.Application.Config;
using FootballHub.Application.Interfaces;
using FootballHub.Application.Repositories;
using FootballHub.Application.Services;
using FootballHub.Infrastructure;
using FootballHub.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Customize as needed
    })
    .AddGoogle(options =>
    {
        options.ClientId = "";
        options.ClientSecret = "";
        options.CallbackPath = "/signin-google"; // Customize as needed
    });

//Add Db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Data repositories
builder.Services.AddHttpClient();
builder.Services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("ApiConfig"));
builder.Services.AddTransient<IGetApiInfoService, GetApiInfoService>();
builder.Services.AddTransient<ICoachService, CoachService>();
builder.Services.AddTransient<IStandingsService, StandingsService>();
builder.Services.AddTransient<IFixtureService, FixtureService>();
builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<IShopService, ShopService>();
//builder.Services.AddHostedService<PlayerUpdateService>();
builder.Services.AddSignalR();

builder.Services.AddCors(options => options.AddPolicy(name: "FrontEnd",
    policy =>
{
    policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("FrontEnd");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
