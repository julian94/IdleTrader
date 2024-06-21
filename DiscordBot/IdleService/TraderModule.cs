using Discord;
using Discord.Interactions;
using System.Threading.Tasks;

namespace DiscordBot.IdleService;


[Group("idle-trader", "Idle Trader - Jump and Trade")]
[CommandContextType(InteractionContextType.Guild, InteractionContextType.BotDm, InteractionContextType.PrivateChannel)]
[NsfwCommand(false)]
public class TraderModule : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("status", "Get the Status of your ship")]
    public async Task StatusCommand() => await RespondAsync("Pong!");

    [Group("trade", "Buy and sell")]
    public class TradingModule : InteractionModuleBase<SocketInteractionContext>
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

    [Group("jump", "Buy and sell")]
    public class JumpingModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("list", "List systems within range.")]
        public async Task ListCommand() => await RespondAsync("Placeholder");

        [SlashCommand("to", "Jump to a new system.")]
        public async Task JumpToCommand(string system) => await RespondAsync("Placeholder");
    }

    [Group("game", "Manage being in the game")]
    public class ManagementModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("join", "Join the game with a new ship.")]
        public async Task JoinCommand(string shipName) => await RespondAsync("Placeholder");

        [SlashCommand("leave", "Leave the game and delete your ship. THIS IS IRREVERSIBLE.")]
        public async Task LeaveCommand() => await RespondAsync("Placeholder");
    }
}
