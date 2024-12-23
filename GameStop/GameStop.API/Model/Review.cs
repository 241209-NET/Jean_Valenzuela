namespace GameStop.API.Model;

public class Review
{
    public int ReviewId { get; set; }
    public required string Description { get; set; }
    public DateOnly Date { get; set; }
    public int Rating { get; set; }
    public required Account Account{ get; set; }
    public required Game Game{ get; set; }
}