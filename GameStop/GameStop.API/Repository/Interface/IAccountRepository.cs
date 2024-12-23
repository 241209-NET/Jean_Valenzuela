using GameStop.API.Model;

namespace GameStop.API.Repository;

public interface IAccountRepository
{
    Account CreateNewAccount(Account account);
    IEnumerable<Account> GetAccounts();
    Account? GetAccountById(int id);
    void UpdateAccount(int id, Account account);
    void DeleteAccountById(int id);

}