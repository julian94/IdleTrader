using IdleEngine.Acting;
using IdleEngine.Model;

namespace IdleEngine;

public class Engine
{
    private EventProcessor EventProcessor { get; set; }
    private Universe Universe { get; set; }

    public void TryDoAction(IAction action) => throw new NotImplementedException();
    public void TryRemoveAction(ActionID id) => throw new NotImplementedException();
    public List<IAction> ListActions() => throw new NotImplementedException();
    public void ListEvents() => throw new NotImplementedException();

    public Player GetPlayer(Guid id) => throw new NotImplementedException();
    public Ship GetShip(Guid id) => throw new NotImplementedException();
    public World GetWorld(Guid id) => throw new NotImplementedException();
    public Universe GetUniverse()
    {
        return Universe;
    }

    public void AddEventListener() => throw new NotImplementedException();
}
