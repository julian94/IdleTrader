using IdleEngine.Acting;
using IdleEngine.Model;

namespace IdleEngine;

public class EventProcessor()
{
    // This needs to become thread-safe.
    // Should also do some batching of some sort as stuff that happens tomorrow doesn't need to be checked particularly often.
    private List<IEvent> UnprocessedEvents { get; set; }

    public void ProcessEvents(Universe universe, DateTime now)
    {
        IEnumerable<IEvent> pastEvents;
        {
            var allUnprocessedEvents = UnprocessedEvents;
            var futureEvents = allUnprocessedEvents.Where(e => e.WhenThisEventHappens > now);
            pastEvents = allUnprocessedEvents.Where(e => e.WhenThisEventHappens <= now);
            UnprocessedEvents = futureEvents.ToList();
        }

        foreach (var e  in pastEvents)
        {
            e.DoEvent(universe);
        }
    }

    public void AddEvent(IEvent e)
    {
        // TODO: check for lock on UnprocessedEvents and potentially await unlock.
        UnprocessedEvents.Add(e);
    }
}
