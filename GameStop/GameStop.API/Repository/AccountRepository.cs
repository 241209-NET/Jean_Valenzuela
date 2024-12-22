using GameStop.API.Data;
using GameStop.API.Model;

namespace GameStop.API.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly GameStopContext _gameStopContext;
    public AccountRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;

    public Account CreateNewAccount(Account account)
    {
        throw new NotImplementedException();
    }

    public Account DeleteAccountById(int id)
    {
        throw new NotImplementedException();
    }

    public Account GetAccountById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAccounts()
    {
        throw new NotImplementedException();
    }

    public Account UpdateAccount(int id, Account account)
    {
        throw new NotImplementedException();
    }
}