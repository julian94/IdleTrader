using IdleEngine.Acting;
using IdleEngine.Model;
using IdleEngine.Time;

namespace IdleEngine;

public class Engine
{
    private EventProcessor EventProcessor { get; set; } = new EventProcessor();

    private Universe Universe { get; set; } = new ();

    private GameTimer Timer { get; set; } = new GameTimer(new Random(), 1.0);

    public bool TryDoAction(IAction action) => action.TryDoAction(Universe, EventProcessor, Timer);

    public void ListEvents() => throw new NotImplementedException();

    public Player? GetPlayer(ulong id) => Universe.Players.FirstOrDefault(p => p.ID == id);

    public Ship? GetShip(ulong playerId) => Universe.Ships.FirstOrDefault(s => s.Owner.ID == playerId);

    public World? GetWorld(Guid id) => throw new NotImplementedException();

    public Universe GetUniverse()
    {
        return Universe;
    }

    public World? GetWorldByNameAndPosition(string name, Position origin)
    {
        var worldCandidates = Universe.Worlds.Where(w => w.Name == name);
        if (worldCandidates.Any())
        {
            return worldCandidates.OrderBy(w => origin.CalculateDistance(w.Position)).First();
        }
        else
        {
            return null;
        }
    }

    public void AddEventListener() => throw new NotImplementedException();

    public void Tick()
    {
        EventProcessor.ProcessEvents(Universe, Timer.Now());
    }
}
