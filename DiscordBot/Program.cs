using Discord;
using Discord.WebSocket;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();

var token = builder.Configuration.GetValue<string>("token") ?? throw new Exception("Missing token");

var discordClient = new DiscordSocketClient();
discordClient.Ready += () =>
{
    Console.WriteLine("Client is ready");
    return Task.CompletedTask;
};
await discordClient.LoginAsync(TokenType.Bot, token);
await discordClient.StartAsync();

if (false)
{
    var commandBuilder = new SlashCommandBuilder();
    var command = commandBuilder
        .WithName("simple-reply")
        .WithDescription("Replies to your command")
        .WithNsfw(false)
        .WithDefaultPermission(true)
        .Build();

    await discordClient.CreateGlobalApplicationCommandAsync(command);
}

discordClient.SlashCommandExecuted += async (SocketSlashCommand command) =>
{
    Console.WriteLine($"Received slash command {command.Id}");
    await command.RespondAsync($"You executed {command.Data.Name}");
    Console.WriteLine($"Responded to slash command {command.Id}");
};


var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app.MapGet("/hello", () =>
{
    discordClient.SetGameAsync(DateTime.Now.ToString());
    return "Hello";
}).WithOpenApi();

app.Run();
