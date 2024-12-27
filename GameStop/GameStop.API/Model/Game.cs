namespace GameStop.API.Model;

public class Game
{
    public int GameId { get; set; }
    public int Version { get; set; }
    public string? Name { get; set; }
    public string? Genre { get; set; }
    public double? Price { get; set; }
    public string? Type { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
}