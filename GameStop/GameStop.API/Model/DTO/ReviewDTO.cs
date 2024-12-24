namespace GameStop.API.DTO;

public class ReviewDTO
{
    public int ReviewId { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public int Rating { get; set; }
}