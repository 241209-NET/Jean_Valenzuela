namespace GameStop.API.DTO;

public class AccountDTO
{
    public int AccountId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int Age { get; set; }
    public int ZipCode { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
}