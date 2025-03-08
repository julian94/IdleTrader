using IdleEngine.Acting;
using IdleEngine.Model;

namespace IdleEngine;

public class EventProcessor()
{
    // This needs to become thread-safe.
    // Should also do some batching of some sort as stuff that happens tomorrow doesn't need to be checked particularly often.
    private List<IEvent> UnprocessedEvents { get; set; } = new List<IEvent>();
    private List<IEvent> ProcessedEvents { get; set; } = new List<IEvent>();

    public void ProcessEvents(Universe universe, DateTime now)
    {
        IEnumerable<IEvent> pastEvents;
        lock (UnprocessedEvents)
        {
            var allUnprocessedEvents = UnprocessedEvents;
            var futureEvents = allUnprocessedEvents.Where(e => e.WhenThisEventHappens > now);
            pastEvents = allUnprocessedEvents.Where(e => e.WhenThisEventHappens <= now);
            UnprocessedEvents = futureEvents.ToList();
        }

        foreach (var e  in pastEvents)
        {
            e.DoEvent(universe);
            ProcessedEvents.Add(e);
        }
    }

    public void AddEvent(IEvent e)
    {
        lock (UnprocessedEvents)
        {
            UnprocessedEvents.Add(e);
        }
    }
}
