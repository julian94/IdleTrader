using Discord;
using Discord.Interactions;
using IdleEngine;
using IdleEngine.Acting;
using IdleEngine.Model;
using System.Threading.Tasks;

namespace DiscordBot.IdleService;


[Group("idle-trader", "Idle Trader - Jump and Trade")]
[CommandContextType(InteractionContextType.Guild, InteractionContextType.BotDm, InteractionContextType.PrivateChannel)]
[NsfwCommand(false)]
public class TraderModule(Engine engine) : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("status", "Get the Status of your ship")]
    public async Task StatusCommand()
    {
        var user = Context.User;
        var ship = engine.GetShip(user.Id);
        if (ship != null)
        {
            await RespondAsync($"Your ship the {ship.Name} is at {ship.Position} and has a jump range of {ship.JumpRange}");
        }
        else
        {
            await RespondAsync("No ship found! Looks like someone might have nicked it.");
        }
    }

    [Group("trade", "Buy and sell")]
    public class TradingModule(Engine engine) : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("search", "Look for traders and get offers.")]
        public async Task SearchCommand() => await RespondAsync("Placeholder");

        [SlashCommand("buy", "Look for traders and get offers.")]
        public async Task BuyCommand(TradeGoods goods, uint amount)
        {
            //var u = Context.User;
            await RespondAsync("Placeholder");
        }

        [SlashCommand("sell", "Look for traders and get offers.")]
        public async Task SellCommand(TradeGoods goods, uint amount) => await RespondAsync("Placeholder");
    }

    [Group("jump", "Travel to other worlds.")]
    public class JumpingModule(Engine engine) : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("list", "List systems within range.")]
        public async Task ListCommand() => await RespondAsync("Placeholder");

        [SlashCommand("to", "Jump to a new world.")]
        public async Task JumpToCommand(string world)
        {
            var ship = engine.GetShip(Context.User.Id);
            if (ship.Position == null || !ship.HasFuel)
            {
                await RespondAsync("Unable to jump, ship is already jumping.");
            }
            var targetWorld = engine.GetWorldByNameAndPosition(world, ship.Position.Value);

            if (targetWorld == null)
            {
                await RespondAsync($"Unable to find a world named {world}.");
            }

            var jumpActionDone = engine.TryDoAction(new JumpAction(ship.ID, targetWorld.Position));

            if (jumpActionDone)
            {
                await RespondAsync($"Your ship is now jumping to {world}");
            }
            else
            {
                await RespondAsync("Unable to jump for some reason.");
            }
        }
    }

    [Group("game", "Manage being in the game")]
    public class ManagementModule(Engine engine) : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("join", "Join the game with a new ship.")]
        public async Task JoinCommand(string shipname)
        {
            var user = Context.User;
            _ = engine.TryDoAction(new ShipCreation(new Ship()
            {
                ID = new(),
                Description = "Really cool ship",
                HasFuel = true,
                JumpRange = 1,
                Name = shipname,
                Position = new(1, 2),
                Owner = new()
                {
                    ID = user.Id,
                    Name = user.GlobalName,
                },
            }));

            await RespondAsync($"{shipname} is ready for your command {user.Mention}");
        }

        [SlashCommand("leave", "Leave the game and delete your ship. THIS IS IRREVERSIBLE.")]
        public async Task LeaveCommand() => await RespondAsync("Placeholder");
    }
}
