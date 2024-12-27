using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Utils;

namespace GameStop.API.Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;

    public Account CreateNewAccount(AccountDTO _account)
    {
        Account account = new();
        DTOToEntityRequest<AccountDTO, Account>.ToEntity(_account, account);
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

    public Account? UpdateAccount(int id, AccountDTO _account)
    {
        var account = GetAccountById(id);

        DTOToEntityRequest<AccountDTO, Account>.ToEntity(_account, account!);

        if (account is not null) _accountRepository.UpdateAccount(id, account);

        return account;
    }
}