namespace GameStop.API.DTO;

public class ResponseAccountDTO(){
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int Age { get; set; }
    public int ZipCode { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }

    public List<AccountOrders>? Orders { get; set; }
    public List<ReviewDTO>? Reviews { get; set; }
}

public class AccountOrders(){
    public string? Status { get; set; }
    public double Total { get; set; }
    public string? PaymentMethod { get; set; }
    public string? ShippingZipCode { get; set; }
    public string? ShippingStreetAddress { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingState { get; set; }
}