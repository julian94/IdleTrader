namespace IdleEngine.Time;

public class GameTimer(Random random, double timeFactor)
{
    public TimeSpan GlobalTimeOffset { get; } = new TimeSpan(365 * 500 + 120, 0, 0, 0, 0, 0); // 500 years in the future

    public DateTime Now() => DateTime.UtcNow.Add(GlobalTimeOffset);

    public DateTime AfterJump() => Now().Add(TimeFrames.JumpTime(random).Multiply(timeFactor));
}
