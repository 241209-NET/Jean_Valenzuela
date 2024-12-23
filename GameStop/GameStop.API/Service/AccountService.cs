using GameStop.API.Model;
using GameStop.API.Repository;

namespace GameStop.API.Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;

    public Account CreateNewAccount(Account account)
    {
        return _accountRepository.CreateNewAccount(account);
    }

    public Account? DeleteAccountById(int id)
    {
        var account = _accountRepository.GetAccountById(id);

        if(account is not null) _accountRepository.DeleteAccountById(id);

        return account;
    }

    public Account? GetAccountById(int id)
    {
        if( id < 1) return null;

        return _accountRepository.GetAccountById(id);
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _accountRepository.GetAccounts();
    }

    public Account? UpdateAccount(int id, Account _account)
    {
        var account = GetAccountById(id);

        if (account is not null) _accountRepository.UpdateAccount(id, _account);

        return account;
    }
}