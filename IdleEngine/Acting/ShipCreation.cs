using IdleEngine.Model;
using IdleEngine.Time;

namespace IdleEngine.Acting;

public class ShipCreation(Ship ship) : IAction
{
    public ActionID ID { get; set; } = new();

    public bool ActionCanBeDone(Universe universe)
    {
        var playerAlreadyHasShip = universe.Ships.Where(s => s.Owner.ID == ship.Owner.ID).Any();
        return playerAlreadyHasShip;
    }

    public bool TryDoAction(Universe universe, EventProcessor eventProcessor, GameTimer timer)
    {
        if (ActionCanBeDone(universe))
        {
            eventProcessor.AddEvent(new AddShipEvent(ship, timer.Now()));
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class AddShipEvent(Ship ship, DateTime timestamp) : IEvent
{
    public EventID EventID { get; } = new();

    public DateTime WhenThisEventHappens { get; } = timestamp;

    public void DoEvent(Universe universe)
    {
        universe.Ships.Add(ship);
    }
}