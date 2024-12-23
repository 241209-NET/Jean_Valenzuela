using GameStop.API.Data;
using GameStop.API.Model;

namespace GameStop.API.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly GameStopContext _gameStopContext;
    public AccountRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;

    public Account CreateNewAccount(Account account)
    {
        _gameStopContext.Accounts.Add(account);
        _gameStopContext.SaveChanges();

        return account;
    }

    public void DeleteAccountById(int id)
    {
        var account = GetAccountById(id);

        _gameStopContext.Accounts.Remove(account!);
        _gameStopContext.SaveChanges();
    }

    public Account? GetAccountById(int id)
    {
        return _gameStopContext.Accounts.Find(id);
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _gameStopContext.Accounts.ToList();
    }

    public void UpdateAccount(int id, Account _account)
    {
        var account = GetAccountById(id)!;

        account.State = _account.State;
        account.FirstName = _account.FirstName;
        account.Street = _account.Street;
        account.LastName = _account.LastName;
        account.Email = _account.Email;
        account.Password = _account.Password;
        account.Age = _account.Age;
        account.City = _account.City;
        account.ZipCode = _account.ZipCode;

        _gameStopContext.SaveChanges();
    }
}