using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IAccountService
{
    Account CreateNewAccount(Account account);
    IEnumerable<Account> GetAccounts();
    Account GetAccountById(int id);
    Account UpdateAccount(int id, Account account);
    Account DeleteAccountById(int id);

}