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
        var account = GetAccountById(id);

        if(account is not null) _accountRepository.DeleteAccountById(id);

        return account;
    }

    public Account? GetAccountById(int id)
    {
        if( id < 1) return null;

        return _accountRepository.GetAccountById(id);
    }

    public IEnumerable<ResponseAccountDTO> GetAccounts()
    {
        var accounts = _accountRepository.GetAccounts();

        List<ResponseAccountDTO> res = [];

        foreach(Account a in accounts)
        {
            ResponseAccountDTO dto = new(){
                Orders = [],
                Reviews = []
            };

            EntityToDTORequest<Account, ResponseAccountDTO>.ToDTO(a, dto);

            foreach(Order order in a.Orders!){
                AccountOrders accountOrders = new();
                EntityToDTORequest<Order, AccountOrders>.ToDTO(order, accountOrders);
                dto.Orders!.Add(accountOrders);
            }

            foreach(Review review in a.Reviews!){
                ReviewDTO orderReview = new();
                EntityToDTORequest<Review, ReviewDTO>.ToDTO(review, orderReview);
                dto.Reviews!.Add(orderReview);
            }

            res.Add(dto);
        }

        return res;
    }

    public Account? UpdateAccount(int id, AccountDTO _account)
    {
        var account = GetAccountById(id);

        DTOToEntityRequest<AccountDTO, Account>.ToEntity(_account, account!);

        if (account is not null) _accountRepository.UpdateAccount(id, account);

        return account;
    }
}