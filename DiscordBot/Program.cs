using Discord;
using Discord.WebSocket;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Discord.Interactions;
using System.Reflection;
using IdleEngine;
using System.Threading.Tasks;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();

var engine = new Engine();
builder.Services.AddSingleton(engine);

var clockToken = new CancellationTokenSource();
_ = ClockTicker(engine, new TimeSpan(0, 0, 0, 0, 100), clockToken.Token);

var app = builder.Build();


var token = builder.Configuration.GetValue<string>("token") ?? throw new Exception("Missing token");

var discordClient = new DiscordSocketClient();
var interactionService = new InteractionService(discordClient);
await interactionService.AddModulesAsync(Assembly.GetExecutingAssembly(), app.Services);

discordClient.Ready += async () =>
{
    Console.WriteLine("Client is prepping modules.");
    await interactionService.RegisterCommandsGloballyAsync();
    Console.WriteLine("Client is ready");
};

discordClient.InteractionCreated += async (x) =>
{
    var ctx = new SocketInteractionContext(discordClient, x);
    await interactionService.ExecuteCommandAsync(ctx, app.Services);
};

await discordClient.LoginAsync(TokenType.Bot, token);
await discordClient.StartAsync();

app.UseSwagger().UseSwaggerUI();

app.MapGet("/hello", () =>
{
    discordClient.SetGameAsync(DateTime.Now.ToString());
    return "Hello";
}).WithOpenApi();

app.MapGet("/universe", () =>
{
    return engine.GetUniverse();
}).WithOpenApi();

app.Run();

static async Task ClockTicker(Engine e, TimeSpan interval, CancellationToken token)
{
    while (!token.IsCancellationRequested)
    {
        await Task.Delay(interval, token);
        e.Tick();
    }
}
