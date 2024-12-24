namespace GameStop.API.DTO;

public class OrderDTO
{
    public int OrderID { get; set; }
    public string? Status { get; set; }
    public double Total { get; set; }
    public string? PaymentMethod { get; set; }
    public string? ShippingZipCode { get; set; }
    public string? ShippingStreetAddress { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingState { get; set; }

}