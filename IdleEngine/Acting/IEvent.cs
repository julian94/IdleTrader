using IdleEngine.Model;

namespace IdleEngine.Acting;

public interface IEvent
{
    public EventID EventID { get; }

    public DateTime WhenThisEventHappens {  get; }

    public void DoEvent(Universe universe);
}
