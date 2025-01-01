using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IAccountService
{
    AccountDTO CreateNewAccount(AccountDTO account);
    IEnumerable<ResponseAccountDTO> GetAccounts();
    ResponseAccountDTO? GetAccountById(int id);
    AccountDTO? UpdateAccount(int id, AccountDTO account);
    ResponseAccountDTO? DeleteAccountById(int id);

}