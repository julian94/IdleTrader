namespace IdleEngine.Model;

public record class Ship
{
    public ShipID ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Player Owner { get; set; }
    public Position? Position { get; set; }
    public int JumpRange { get; set; }
    public bool HasFuel { get; set; }
}
