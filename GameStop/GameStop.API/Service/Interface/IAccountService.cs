using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IAccountService
{
    Account CreateNewAccount(AccountDTO account);
    IEnumerable<Account> GetAccounts();
    Account? GetAccountById(int id);
    Account? UpdateAccount(int id, AccountDTO account);
    Account? DeleteAccountById(int id);

}