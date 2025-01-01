using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace GameStop.API.Model;

public class Review
{
    public int ReviewId { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public int Rating { get; set; }

    [ForeignKey("Account")]
    public int AccountId { get; set; }

    [ForeignKey("Game")]
    public int GameId { get; set; }
    public virtual required Account? Account{ get; set; }
    public virtual required Game? Game{ get; set; }
}