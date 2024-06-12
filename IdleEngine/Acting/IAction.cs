using IdleEngine.Model;
using IdleEngine.Time;

namespace IdleEngine.Acting;

public interface IAction
{
    public ActionID ID { get; set; }
    public bool ActionCanBeDone(Universe universe);
    public bool TryDoAction(Universe universe, IList<IEvent> eventList, GameTimer timer);
}
