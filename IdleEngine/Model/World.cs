namespace IdleEngine.Model;

public record class World
{
    public WorldID ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Position Position { get; set; }
}
