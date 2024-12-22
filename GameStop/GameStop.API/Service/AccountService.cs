using GameStop.API.Model;

namespace GameStop.API.Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;

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