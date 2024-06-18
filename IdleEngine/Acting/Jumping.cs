using IdleEngine.Model;
using IdleEngine.Time;

namespace IdleEngine.Acting;

public class JumpAction(ShipID shipID, Position destination) : IAction
{
    public const string ActionName = "jump";

    public ActionID ID { get; set; } = new();

    public bool ActionCanBeDone(Universe universe)
    {
        var ship = universe.Ships.Where(s => s.ID == shipID).FirstOrDefault();

        var isInRange = ship is not null && ship.Position.HasValue && ship.Position.Value.CalculateDistance(destination) < ship.JumpRange;
        var hasSufficientFuel = ship is not null && ship.HasFuel;

        return isInRange && hasSufficientFuel;
    }

    public bool TryDoAction(Universe universe, IList<IEvent> eventList, GameTimer timer)
    {
        if (ActionCanBeDone(universe))
        {
            eventList.Add(new JumpEntryEvent(shipID, timer.Now()));
            eventList.Add(new JumpArrivalEvent(shipID, destination, timer.AfterJump()));
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryDoAction(Universe universe, EventProcessor eventProcessor, GameTimer timer)
    {
        if (ActionCanBeDone(universe))
        {
            eventProcessor.AddEvent(new JumpEntryEvent(shipID, timer.Now()));
            eventProcessor.AddEvent(new JumpArrivalEvent(shipID, destination, timer.AfterJump()));
            
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class JumpEntryEvent(ShipID shipID, DateTime timestamp) : IEvent
{
    public EventID EventID { get; } = new();

    public DateTime WhenThisEventHappens { get; } = timestamp;

    public void DoEvent(Universe universe)
    {
        var ship = universe.Ships.Where(s => s.ID == shipID).FirstOrDefault();
        ship.Position = null;
        ship.HasFuel = false;
    }
}

public class JumpArrivalEvent(ShipID shipID, Position destination, DateTime timestamp) : IEvent
{
    public EventID EventID { get; } = new();

    public DateTime WhenThisEventHappens { get; } = timestamp;

    public void DoEvent(Universe universe)
    {
        var ship = universe.Ships.Where(s => s.ID == shipID).FirstOrDefault();
        ship.Position = destination;
    }
}
