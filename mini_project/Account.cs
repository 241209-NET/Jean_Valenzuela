class Account()
{
    public double Balance { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmailAddress { get; set; }
    public string? Username { get; set; }

    public void Deposit(double money)
    {
        Balance += money;
    }
    public void Withdraw(double money)
    {
        Balance -= money;
    }
}