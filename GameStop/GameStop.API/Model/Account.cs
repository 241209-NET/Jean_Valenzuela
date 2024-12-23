namespace GameStop.API.Model;

public class Account
{
    public int AccountId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int Age { get; set; }
    public int ZipCode { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public List<Order>? Orders { get; set; }
    public List<Review>? Reviews { get; set; }
}