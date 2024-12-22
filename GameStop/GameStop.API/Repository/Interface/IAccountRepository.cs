using GameStop.API.Model;

namespace GameStop.API.Repository;

public interface IAccountRepository
{
    Account CreateNewAccount(Account account);
    IEnumerable<Account> GetAccounts();
    Account GetAccountById(int id);
    Account UpdateAccount(int id, Account account);
    Account DeleteAccountById(int id);

}