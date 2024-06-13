using IdleEngine.Acting;
using IdleEngine.Model;
using IdleEngine.Time;

namespace IdleEngine;

public class EventProcessor(GameTimer timer)
{
    // This needs to become thread-safe.
    // Should also do some batching of some sort as stuff that happens tomorrow doesn't need to be checked particularly often.
    private List<IEvent> UnprocessedEvents { get; set; }

    public void ProcessEvents(Universe universe)
    {
        IEnumerable<IEvent> pastEvents;
        {
            var processingTimestamp = timer.Now();
            var allUnprocessedEvents = UnprocessedEvents;
            var futureEvents = allUnprocessedEvents.Where(e => e.WhenThisEventHappens > processingTimestamp);
            pastEvents = allUnprocessedEvents.Where(e => e.WhenThisEventHappens <= processingTimestamp);
            UnprocessedEvents = futureEvents.ToList();
        }

        foreach (var e  in pastEvents)
        {
            e.DoEvent(universe);
        }
    }

    public void AddEvent(IEvent e) => throw new NotImplementedException();
}
