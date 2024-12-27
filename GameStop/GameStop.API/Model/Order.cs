using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace GameStop.API.Model;

public class Order
{
    public int OrderId { get; set; }
    public string? Status { get; set; }
    public double Total { get; set; }
    public string? PaymentMethod { get; set; }
    public string? ShippingZipCode { get; set; }
    public string? ShippingStreetAddress { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingState { get; set; }

    [ForeignKey("Account")]
    public int AccountId { get; set; }
    public ICollection<Game>? Games { get; set; }
    public virtual Account? Account { get; set; } 
}