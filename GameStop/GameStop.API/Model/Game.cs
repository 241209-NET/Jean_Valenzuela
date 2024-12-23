namespace GameStop.API.Model;

public class Game
{
    public int GameId { get; set; }
    public int Version { get; set; }
    public required string Name { get; set; }
    public required string? Genre { get; set; }
    public required double? Price { get; set; }
    public string? Type { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public List<Order>? Orders { get; set; }
    public List<Review>? Reviews { get; set; }
}