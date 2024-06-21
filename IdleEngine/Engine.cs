using IdleEngine.Acting;
using IdleEngine.Model;
using IdleEngine.Time;

namespace IdleEngine;

public class Engine
{
    private EventProcessor EventProcessor { get; set; }

    private Universe Universe { get; set; } = new ();

    private GameTimer Timer { get; set; }

    public bool TryDoAction(IAction action) => action.TryDoAction(Universe, EventProcessor, Timer);

    public void ListEvents() => throw new NotImplementedException();

    public Player? GetPlayer(ulong id) => Universe.Players.FirstOrDefault(p => p.ID == id);

    public Ship? GetShip(ulong playerId) => Universe.Ships.FirstOrDefault(s => s.Owner.ID == playerId);

    public World? GetWorld(Guid id) => throw new NotImplementedException();

    public Universe GetUniverse()
    {
        return Universe;
    }

    public void AddEventListener() => throw new NotImplementedException();
}
