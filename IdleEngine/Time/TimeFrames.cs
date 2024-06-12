namespace IdleEngine.Time;

public static class TimeFrames
{
    public static TimeSpan OneDSeconds(Random random) => new (hours: 0, minutes: 0, seconds: random.D6());
    public static TimeSpan OneDCombatRounds(Random random) => new (hours: 0, minutes: 0, seconds: random.D6());
    public static TimeSpan OneDxTenSeconds(Random random) => new (hours: 0, minutes: 0, seconds: random.D6());
    public static TimeSpan OneDHours(Random random) => new (hours: random.D6(), minutes: 0, seconds: 0);
    public static TimeSpan OneDxFourHours(Random random) => new (hours: random.D6() * 4, minutes: 0, seconds: 0);
    public static TimeSpan OneDxTenHours(Random random) => new (hours: random.D6() * 10, minutes: 0, seconds: 0);
    public static TimeSpan OneDDays(Random random) => new (days: random.D6(), hours: 0, minutes: 0, seconds: 0);
    public static TimeSpan JumpTime(Random random) => new (days: 0, hours: 148 + random.D6(), minutes: 0, seconds: 0);
    private static int D6(this Random random) => random.Next(1, 6);
}
