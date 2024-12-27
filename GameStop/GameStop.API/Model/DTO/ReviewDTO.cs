namespace GameStop.API.DTO;

public class ReviewDTO
{
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public int Rating { get; set; }
}