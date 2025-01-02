using GameStop.API.Model;

namespace GameStop.API.DTO;

public class ResponseReviewDTO
{
    public int ReviewId { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public int Rating { get; set; }
    public AccountDTO? Account { get; set; }
}