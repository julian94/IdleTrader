using IdleEngine.Acting;
using IdleEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleEngine;

public class Engine
{
    private List<IEvent> EventLog { get; set; }
    private Universe Universe { get; set; }

    public void TryAddAction(IAction action) => throw new NotImplementedException();
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
