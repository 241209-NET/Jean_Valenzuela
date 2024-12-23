namespace GameStop.API.Model;

public class Order
{
    public int OrderID { get; set; }
    public string? Status { get; set; }
    public double Total { get; set; }
    public required string PaymentMethod { get; set; }
    public string? ShippingZipCode { get; set; }
    public string? ShippingStreetAddress { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingState { get; set; }
    public List<Game>? Games { get; set; }
    public required Account Account { get; set; } 
}